
namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

internal class DependencyImplementation : IDependency
{
    public int Create(Dependency item)//Dependency's entity Create operation
    {
        if ((DataSource.Tasks.Find(x => x.Id == item.DependsOnTask) == null) && (DataSource.Tasks.Find(x => x.Id == item.DependentTask) == null))//If the engineer has task
            throw new LogicalError($"Cannot create a dependency on a task that does not exist");
       // Check if the dependency already exists
        if (DataSource.Dependencys.Any(dep => dep.DependentTask == item.DependentTask && dep.DependsOnTask == item.DependsOnTask))
            throw new DalAlreadyExistsException($"Dependency is already exists");

        int id = DataSource.Config.NextDependencyId;//for entities with auto id
        Dependency copy = item with { Id = id };//copy ID
        DataSource.Dependencys.Add(copy);//Adding
        return id;
    }

  
    public void Delete(int? id=null)//Dependency's entity Delete operation
    {
        if (id == null)
            DataSource.Dependencys.Clear();
        else {   Dependency? dependency = Read((int)id!);//reading according to ID 
        if (dependency is null)//Exception
            throw new DalDoesNotExistException($"dependency with ID = {id} does Not exists");
        else
            DataSource.Dependencys.Remove(dependency);//remove the dependency
                                                      //
         }
      
    }


    public Dependency? Read(int id)//Dependency's entity Read operation
    {
        return DataSource.Dependencys.FirstOrDefault(dp=> dp.Id == id);//find for reading according to ID 
    }
    public Dependency? Read(Func<Dependency, bool> filter)
    { return DataSource.Dependencys.FirstOrDefault(item => filter(item)); }// stage 2


    public IEnumerable<Dependency> ReadAll(Func<Dependency, bool>? filter = null) //stage 2
    {
        if (filter != null)
        {
            return from item in DataSource.Dependencys
                   where filter(item)
                   select item;
        }
        return from item in DataSource.Dependencys
               select item;
    }

    public void Update(Dependency item)//Dependency's entity Update operation
    {
        Dependency? dependency = Read(item.Id);
        if (dependency is null)//Exception
            throw new DalDoesNotExistException($"Dependency with ID={item.Id} does Not exists");
        else 
        {
            if (DataSource.Dependencys.Any(dep => dep.DependentTask == item.DependentTask && dep.DependsOnTask == item.DependsOnTask))
                throw new DalAlreadyExistsException($"Dependency is already exists");
            DataSource.Dependencys.Remove(dependency);//remove the old dependency
        DataSource.Dependencys.Add(item);//add the new dependency
        }
    }
}
