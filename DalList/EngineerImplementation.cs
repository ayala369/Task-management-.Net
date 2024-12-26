namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

internal class EngineerImplementation : IEngineer
{
    public int Create(Engineer item)//Engineer's entity Create operation
    {
        if (Read(item.Id) is not null)//for entities with normal id (not auto id)
            throw new DalAlreadyExistsException($"Engineer with ID={item.Id} already exists");//if the id already exists
        DataSource.Engineers.Add(item);//Adding
        return item.Id;
    }


    public void Delete(int? id=null)//Engineer's entity Delete operation
        {
        if (id == null)
            DataSource.Engineers.Clear();
        else { Engineer? eng = Read((int)id!);//reading according to ID 
            if (eng is null)//Exception
                throw new DalDoesNotExistException($"Engineers with ID={id} does Not exists");
            else
            {
                if (DataSource.Tasks.Find(x => x.Engineerld == id) != null)//If the engineer has task
                    throw new DalDeletionImpossible($"Engineerld with ID={id} cannot be deleted");
                ////remove the Engineer
                DataSource.Engineers.Remove(eng);
            }
        }
       
        
    }

    public Engineer? Read(Func<Engineer, bool> filter)
    { return DataSource.Engineers.FirstOrDefault(item => filter(item)); }// stage 2


    public Engineer? Read(int id)//Engineer's entity Read operation
    {
        return DataSource.Engineers.FirstOrDefault(eg => eg.Id == id);//find for reading according to ID 
    }

    public IEnumerable<Engineer> ReadAll(Func<Engineer, bool>? filter = null) //stage 2
    {
        if (filter != null)
        {
            return from item in DataSource.Engineers
                   where filter(item)
                   select item;
        }
        return  from item in DataSource.Engineers
               select item;
    }

    public void Update(Engineer item)//Engineer's entity Update operation
    {
        Engineer? engineer = Read(item.Id);
        if (engineer is null)//Exception
            throw new DalDoesNotExistException($"Engineer with ID={item.Id} does Not exists");
        DataSource.Engineers.Remove(engineer);//remove the old engineer
        DataSource.Engineers.Add(item);//add the old engineer
    }
}
