using BlApi;
using BO;

namespace BlImplementation
{
    internal class TaskImplementation : ITask
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(BO.Task boTask)//function to create a new task
        {

            if ((boTask.Id < 0) || (boTask.Alias == ""))
                throw new BO.BlInvalidDataException("the item is not valid");

            bool mileS = boTask.Milestone == null ? false : true;


            DO.Task doTask = new DO.Task(boTask.Id, boTask.Description!, boTask.Alias!, null, mileS, null ,
                boTask.CreatedAtDate, boTask.StartDate, boTask.ForecastDate, boTask.DeadlineDate, boTask.CompleteDate, boTask.Deliverables, boTask.Remarks, (DO.EngineerExperience)boTask.ComplexityLevel);

            try
            {
                boTask.Dependencies!.ForEach((dependency) =>
                {
                    _dal.Dependency.Create(new DO.Dependency(0, boTask.Id, dependency.Id));
                });
                int idEng = _dal.Task.Create(doTask);
                return idEng;
            }
            catch (DO.DalAlreadyExistsException ex)
            {
                throw new BO.BlAlreadyExistsException($"error in create dependency", ex);
            }
        }

        //בהערה עד להוראות מהמורה
        //public int Delete(int id)
        //{
        //    try
        //    {
        //        _dal.Task.Delete(id);
        //    }
        //    catch (DO.DalDeletionImpossible ex)
        //    {
        //        throw new BlDeletionImpossible($"task with id {id} has some dependencies tasks or the project already began", ex);
        //    }
        //    catch (DO.DalDoesNotExistException ex)
        //    {
        //        throw new BlDoesNotExistException($"task with id {id} doesnt exist", ex);
        //    }
        //    return id;
        //}


        public BO.Task? Read(int id)//A function to read a task
        {

            DO.Task? doTask = _dal.Task.Read(id);
            if (doTask == null)
                throw new BO.BlDoesNotExistException($"Task with ID={id} does Not exist");
            try
            {
                return new BO.Task()//Building a type BO engineer
                {
                    Id = id,
                    Description = doTask.Description,
                    Alias = doTask.Alias,
                    Milestone = doTask.Milestone ? new BO.MilestoneInTask() : null,
                    Status = StatusCalculation(doTask),
                    CreatedAtDate = doTask.CreatedAt,
                    BaselineStartDate = null,
                    StartDate = doTask.Start,
                    ForecastDate = doTask.ScheduledDate,
                    DeadlineDate = doTask.Deadline,
                    CompleteDate = doTask.Complete,
                    Deliverables = doTask.Deliverables,
                    Remarks = doTask.Remarks,
                    Dependencies = DependenciesCalculation(doTask.Id),
                    Engineer = doTask.Engineerld.HasValue ? EngineerCalculation(doTask.Engineerld!.Value) : null,
                    ComplexityLevel = (BO.EngineerExperience)(doTask.ComplexityLevel!)

                };
            }
            catch (DO.DalAlreadyExistsException ex)
            {
                throw new BO.BlAlreadyExistsException($"error in read Task with ID={doTask.Id}", ex);
            }

        }

        public IEnumerable<BO.Task> ReadAll(Func<BO.Task, bool>? filter = null)//A function to read  all the tasks
        {
            IEnumerable<BO.Task> tasks = _dal.Task.ReadAll().Select(doTask => Read(doTask!.Id))!;
            if (filter == null)
                return tasks;
            return tasks.Where(filter);
        }




        public void Update(BO.Task boTask)//A function to update a task
        {
            if (boTask == null)
            {
                throw new BO.BlInvalidDataException("Task object cannot be null");
            }
            if ((boTask.Id <= 0) || (boTask.Alias == ""))
                throw new BO.BlInvalidDataException("the item is not valid");

            bool mileS = boTask.Milestone == null ? false : true;
            DO.Task doTask = new DO.Task
                 (boTask.Id, boTask.Description!, boTask.Alias!, boTask.Engineer!.Id, mileS, null , boTask.CreatedAtDate, boTask.StartDate, boTask.ForecastDate, boTask.DeadlineDate, boTask.CompleteDate, boTask.Deliverables, boTask.Remarks, (DO.EngineerExperience)boTask.ComplexityLevel);
            try
            {
                boTask.Dependencies!.ForEach((dependency) =>
                {
                    _dal.Dependency.Create(new DO.Dependency(0, boTask.Id, dependency.Id));
                });
                _dal.Task.Update(doTask);
            }
            catch (DO.DalDoesNotExistException exception)
            {
                throw new BO.BlDoesNotExistException($"error in create dependency ", exception);
            }
        }

        //An auxiliary function for an engineer's calculation
        private EngineerInTask EngineerCalculation(int id)
        {
            var engineer = _dal.Engineer.Read(id);

            if (engineer != null)
            {
                return new BO.EngineerInTask()
                {
                    Id = id,
                    Name = engineer.Name
                };
            }
            else
            {
                // Handle the case when the engineer is not found (e.g., return a default or throw an exception)
                return new BO.EngineerInTask(); // or throw new SomeException("Engineer not found");
            }
        }
        private List<TaskInList> DependenciesCalculation(int id)
        {
            /*פונקציה שמקבלת ID ומכילה שאילתה שעוברת על כל רשימת המשימות ועבור כל משימה שתכונת ה:DependentTask שלה שווה ל:ID ,
 אני רוצה לקבל משימה שהID שלה הוא כערך DependsOnTask של התלות*/
            IEnumerable<DO.Dependency> allDeps = _dal.Dependency.ReadAll()!;
            IEnumerable<DO.Task> allTasks = _dal.Task.ReadAll()!;

            var dependentTasks = allDeps.Where(dep => dep.DependentTask == id);
            List<BO.TaskInList> resultDeps = new List<BO.TaskInList>();
            foreach (var dependentTask in dependentTasks)
            {
                int dependsOnTaskId = dependentTask.DependsOnTask;
                DO.Task dependsOnTask = allTasks.FirstOrDefault(task => task.Id == dependsOnTaskId)!;
                if (dependsOnTask != null)
                {
                    BO.TaskInList boDependsOnTask = ConvertToBOTask(dependsOnTask);
                    resultDeps.Add(boDependsOnTask);
                }
            }

            return resultDeps;
        }

        // Helper method to convert DO.Task to BO.Task
        private BO.TaskInList ConvertToBOTask(DO.Task doTask)
        {
            return new BO.TaskInList()
            {
                Id = doTask.Id,
                Description = doTask.Description,
                Alias = doTask.Alias,
                Status = StatusCalculation(doTask)
            };
        }
        //An auxiliary function for an status's calculation
        private BO.TaskStatus StatusCalculation(DO.Task task)
        {
            return task.Complete != null ? BO.TaskStatus.InJeopardy
                : task.Start != null ? BO.TaskStatus.OnTrack
                : task.ScheduledDate != null ? BO.TaskStatus.Scheduled
                : BO.TaskStatus.Unscheduled;
        }
    }
}
