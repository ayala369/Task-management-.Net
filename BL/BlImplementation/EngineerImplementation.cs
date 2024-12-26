using BlApi;
using BO;

namespace BlImplementation
{
    internal class EngineerImplementation : IEngineer
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;
       

        public int Create(BO.Engineer boEngineer)
        {
            // Verifying the correctness of the data*/
            if ( (boEngineer.Id <= 0)|| (boEngineer.Name == "")|| (boEngineer.Cost <= 0)|| (!IsValidEmail(boEngineer.Email!)))
                throw new BO.BlInvalidDataException("one or more of the details is not valid");

            DO.Engineer doEngineer = new DO.Engineer
                (boEngineer.Id, boEngineer.Name!, boEngineer.Email!, (DO.EngineerExperience?)boEngineer.Level, boEngineer.Cost);

            try
            {
                // Attempt to create the engineer in the system
                int idEng = _dal.Engineer.Create(doEngineer);
                return idEng;
            }
            catch (DO.DalAlreadyExistsException ex)
            {// in case of failure (engineer already exists), triggers an exception of another type and passes the information about the original exception
                throw new BO.BlAlreadyExistsException($"error in crate of Engineer with ID={boEngineer.Id}", ex);
            }
        }
        //בהערה עד לקבלת הוראות מהמורה
        //public int Delete(int id)
        //{
        //    if (FindCurrentTask(id) != null)
        //    {
        //        //if (!_dal.Task.ReadAll((task) => task.EngineerId == id && task.Complete < DateTime.Now).Any())

        //        try
        //        {
        //            _dal.Engineer.Delete(id);
        //        }
        //        catch (DO.DalDoesNotExistException)
        //        {
        //            throw new BO.BlDoesNotExistException($"Engineer with ID={id} already exists", null!);
        //        }
        //        catch (DO.DalDeletionImpossible ex)

        //        {
        //            throw new BO.BlDeletionImpossible($"Engineer with ID={id} has some tasks", ex);
        //        }

        //    }
        //    return id;
        //}


        public BO.Engineer? Read(int id)
        {
            DO.Engineer? doEngineer = _dal.Engineer.Read(id);
            if (doEngineer == null)
                throw new BO.BlDoesNotExistException($"An object of type Engineer with ID {id} does not exist");
            //Finding an engineer's current task
            var tasks = _dal.Task.ReadAll();
            var engTask = (from task in tasks//Finding an engineer's current task
                           where task.Engineerld == id && task.Start is not null && task.Complete is null
                           select new { task.Id, task.Alias }).FirstOrDefault();
            TaskInEngineer? taskInEngineer = null;
            if (engTask is not null)
                taskInEngineer = new TaskInEngineer() { Id = engTask.Id, Alias = engTask.Alias };
            return new BO.Engineer()
            {
                Id = id,
                Name = doEngineer.Name,
                Email = doEngineer.Email,
                Level = (BO.EngineerExperience)doEngineer.Level!,
                Cost = doEngineer.Cost,
                Task = taskInEngineer
            };
        }

        public BO.Engineer? Read(Func<BO.Engineer, bool> filter)
        {//function to read  engineers
            
                return ReadAll(filter).FirstOrDefault();
        }

        public IEnumerable<BO.Engineer?> ReadAll(Func<BO.Engineer, bool>? filter = null)
        {//function to read all engineers
            var doEngList = _dal.Engineer.ReadAll();
            List<BO.Engineer?> boEngList = new List<BO.Engineer?>();
          
            foreach (var engineer in doEngList)
            {
                var boEng = Read(engineer!.Id);
                if (filter != null)
                {
                    if (filter(boEng!))
                    { 
                        if (boEng != null)
                        {
                            boEngList.Add(boEng);
                        }
                    }
                }
                else
                {
                    if (boEng != null)
                    {
                        boEngList.Add(boEng);
                    }
                }
            }

            return boEngList;
        }


        public void Update(BO.Engineer boEngineer)
        {
            // Verifying the correctness of the data*/
            if ((boEngineer.Id <= 0) || (boEngineer.Name == "") || (boEngineer.Cost <= 0) || (!IsValidEmail(boEngineer.Email!)))
                throw new BO.BlInvalidDataException("one or more of the details is not valid");
            DO.Engineer doEngineer = new DO.Engineer
            (boEngineer.Id, boEngineer.Name!, boEngineer.Email!, (DO.EngineerExperience)boEngineer.Level!, boEngineer.Cost);
            try
            {
                _dal.Engineer.Update(doEngineer);
            }
            catch (DO.DalDoesNotExistException exception)
            {
                throw new BO.BlDoesNotExistException($"error in update Engineer with ID {boEngineer.Id} ", exception);
            }

        }
        /************auxiliary operations****************/
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            string[] parts = email.Split('@');
            if (parts.Length != 2)
            {
                return false; // email must have exactly one @ symbol
            }

            string localPart = parts[0];
            string domainPart = parts[1];
            if (string.IsNullOrWhiteSpace(localPart) || string.IsNullOrWhiteSpace(domainPart))
            {
                return false; // local and domain parts cannot be empty
            }

            // check local part for valid characters
            foreach (char c in localPart)
            {
                if (!char.IsLetterOrDigit(c) && c != '.' && c != '_' && c != '-')
                {
                    return false; // local part contains invalid character
                }
            }

            // check domain part for valid format
            if (domainPart.Length < 2 || !domainPart.Contains(".") || domainPart.Split(".").Length != 2 || domainPart.EndsWith(".") || domainPart.StartsWith("."))
            {
                return false; // domain part is not a valid format
            }

            return true;
        }

    }
}
