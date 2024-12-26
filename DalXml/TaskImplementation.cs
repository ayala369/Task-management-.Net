namespace Dal;
using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

internal class TaskImplementation : ITask
{
    public int Create(Task item)
    {
        List<Task> tasksList = XMLTools.LoadListFromXMLSerializer<Task>("tasks");
        int id = Config.NextTaskId;
        Task copy = item with { Id = id };
        tasksList.Add(copy);
        XMLTools.SaveListToXMLSerializer<Task>(tasksList, "tasks");
        return id;
    }

    public void Delete(int? id=null)
    {
        List<Task> tasksList = XMLTools.LoadListFromXMLSerializer<Task>("tasks");

        if (id == null)
        {
            List<Task> newList = new List<Task>();
            XMLTools.SaveListToXMLSerializer<Task>(newList, "tasks");
            return;
        }
        if (id == 0)
            tasksList.Clear();
        else {  if (Read((int)id!) is null)
            throw new DalDoesNotExistException($"An object of type Task with ID {id} doesnt exists");
        tasksList.RemoveAll(t => t.Id == id);
        XMLTools.SaveListToXMLSerializer<Task>(tasksList, "tasks");
}
       
    }

    public Task? Read(int id)
    {
        List<Task> tasksList = XMLTools.LoadListFromXMLSerializer<Task>("tasks");
        Task? foundTask = tasksList.FirstOrDefault(e => e.Id == id);
        if (foundTask != null)
        {
            return foundTask;
        }
        return null;
        //throw new DalDoesNotExistException($"Cannot read Task with ID:{id}.");
    }

        public Task? Read(Func<Task, bool> filter)
    {
        List<Task> tasksList = XMLTools.LoadListFromXMLSerializer<Task>("tasks"); 
        Task? foundTask = tasksList.FirstOrDefault(filter);
        if (foundTask != null)
        {
            return foundTask;
        }
        throw new DalDoesNotExistException($"There is no Task of this filter.");
    }

    public IEnumerable<Task?> ReadAll(Func<Task, bool>? filter = null)
    {
        List<Task> tasksList = XMLTools.LoadListFromXMLSerializer<Task>("tasks");

        if (filter != null)
        {
            List<Task> foundTasks = tasksList.Where(filter).ToList();
            if (foundTasks.Count > 0)
                return foundTasks;
            throw new DalDoesNotExistException($"There is no tasks to read.");
        }
        else
        {
            if (tasksList.Count > 0)
                return tasksList;
            throw new DalDoesNotExistException($"There is no tasks to read.");
        }
    }

    public void Update(Task item)
    {
        List<Task> tasksList = XMLTools.LoadListFromXMLSerializer<Task>("tasks");
        Task? existingTask = tasksList.FirstOrDefault(e => e.Id == item.Id);
        if (existingTask == null)
            throw new DalDoesNotExistException($"An object of type task with ID {item.Id} doesn't exist");
        tasksList.Remove(existingTask);
        tasksList.Add(item);
        XMLTools.SaveListToXMLSerializer<Task>(tasksList, "tasks");
    }
}
