namespace Dal;
using DalApi;
using DO;
using System;
using System.Collections.Generic;

internal class EngineerImplementation : IEngineer
{
    public int Create(Engineer item)
    {
        List<Engineer> engineersList = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");

        // Check if Engineer with the same ID already exists
        if (Read(item.Id) == null)
        {
            engineersList.Add(item);
            XMLTools.SaveListToXMLSerializer<Engineer>(engineersList, "engineers");
            return item.Id;
        }

        throw new DalAlreadyExistsException($"An object of type Engineer with ID {item.Id} already exists");
    }

    public void Delete(int? id=null)
    {
        List<Engineer> engineersList = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");

        if (id == null)
        {
            List<Engineer> emptyList = new List<Engineer>();
            XMLTools.SaveListToXMLSerializer<Engineer>(emptyList, "engineers");
            return;
        }
       

        else
        { if (Read((int)id!) is null)
            throw new DalDoesNotExistException($"An object of type Engineer with ID {id} doesnt exists");
        //if (engineersList.FirstOrDefault(x => x.Id == id) != null)//checking if we can delete it
        //    throw new DalDeletionImpossible($"Engineer with ID={id} has some tasks");
        else
        {
            engineersList.RemoveAll(t => t.Id == id);
            XMLTools.SaveListToXMLSerializer<Engineer>(engineersList, "engineers");
            // Engineer.counterEngineers--;
        } }
       
    }

    public Engineer? Read(int id)
    {
        List<Engineer> engineersList = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");
        Engineer? foundEng = engineersList.FirstOrDefault(e => e.Id == id);
        if (foundEng != null)
        {
            return foundEng;
        }
        return null;    
        //throw new DalDoesNotExistException($"Cannot read Engineer with ID:{id}.");
    }

    public Engineer? Read(Func<Engineer, bool> filter)
    {
        List<Engineer> engineersList = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");
        Engineer? foundEng = engineersList.FirstOrDefault(filter);
        if (foundEng != null)
        {
            return foundEng;
        }
        throw new DalDoesNotExistException($"There is no Engineer of this filter.");
    }

    public IEnumerable<Engineer?> ReadAll(Func<Engineer, bool>? filter = null)
    {
        List<Engineer> engineersList = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");

        if (filter != null)
        {
            List<Engineer> foundEngineers = engineersList.Where(filter).ToList();
            if (foundEngineers.Count > 0)
                return foundEngineers;
            throw new DalDoesNotExistException($"There is no Engineers to read.");
        }
        else
        {
            if (engineersList.Count > 0)
                return engineersList;
            throw new DalDoesNotExistException($"There is no Engineers to read.");
        }
    }

    public void Update(Engineer item)
    {
        List<Engineer> engineersList = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");
        Engineer? existingEngineer = engineersList.FirstOrDefault(e => e.Id == item.Id);
        if (existingEngineer == null)
            throw new DalDoesNotExistException($"An object of type Engineer with ID {item.Id} doesn't exist");
        engineersList.Remove(existingEngineer);
        engineersList.Add(item);
        XMLTools.SaveListToXMLSerializer<Engineer>(engineersList, "engineers");
    }
}

