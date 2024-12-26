namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

internal class TaskImplementation : ITask
{
    public int Create(Task item)//Task's entity Create operation
    {
        int id = DataSource.Config.NextTaskId;//for entities with auto id
        Task copy = item with { Id = id };//copy ID
        DataSource.Tasks.Add(copy);//Adding
        return id;
    }

    public void Delete(int? id = null)//Task's entity Delete operation
    {
        if (id==null)
            DataSource.Tasks.Clear();
        else 
        { 
        Task? task = Read((int)id!);//reading according to ID 
        if (task is null)//Exception
            throw new DalDoesNotExistException($"task with ID={id} does Not exists");
        else
        {
            if (DataSource.Dependencys.Find(x => x.DependsOnTask == id) != null)//Checking if there is a task that depends on the current task
                throw new DalDeletionImpossible($"task with ID={id} cannot be deleted");
            //Checking whether the current task does not depend on any other task
            List<Dependency> dp = DataSource.Dependencys.FindAll(x => x.DependentTask == id);
            foreach (Dependency dependency in dp)
            {
                Delete(dependency.Id);//delete of the dependency with the suit id
            }
            //If possible delete
            DataSource.Tasks.Remove(task);//remove the Task
        }}
       

    }
    public Task? Read(Func<Task, bool> filter)
    { return DataSource.Tasks.FirstOrDefault(item => filter(item)); }// stage 2
    
    public Task? Read(int id)//Task's entity Read operation
    {
        return DataSource.Tasks.FirstOrDefault(ts => ts.Id == id);//find for reading according to ID 
    }

    public IEnumerable<Task> ReadAll(Func<Task, bool>? filter = null) //stage 2
    {//Task's entity ReadAll operation
        if (filter != null)
        {
            return from item in DataSource.Tasks
                   where filter(item)
                   select item;
        }
        return from item in DataSource.Tasks
               select item;
    }
    public void Update(Task item)//Task's entity Update operation
    {
        Task? task = Read(item.Id);
        if (task is null)//Exception
            throw new DalDoesNotExistException($"task with ID={item.Id} does Not exists");
        DataSource.Tasks.Remove(task);//remove the old task
        DataSource.Tasks.Add(item);//add the old task
    }
}
