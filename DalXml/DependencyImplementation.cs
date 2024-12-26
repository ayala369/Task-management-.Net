namespace Dal;
using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

internal class DependencyImplementation : IDependency
{
    const string DependencysFile = @"..\xml\dependencys.xml";

    public int Create(Dependency item)
    {
        XElement? dependencysElements = XDocument.Load(DependencysFile).Root;
        int id = Config.NextDependencyId;
        XElement newDependencyElement = new XElement("Dependency",
               new XElement("Id", id),
               new XElement("DependentTask", item.DependentTask),
               new XElement("DependsOnTask", item.DependsOnTask));
        dependencysElements?.Add(newDependencyElement);
        dependencysElements?.Save(DependencysFile);
        return id;
    }

    public void Delete(int? id=null)
    {
        XElement? dependencysElements = XDocument.Load(DependencysFile).Root;
        XElement? dependencyToDelete = dependencysElements?.Elements().FirstOrDefault(dependency => Convert.ToInt32(dependency?.Element("Id")?.Value) == id);
        if (id == null)
            dependencysElements?.RemoveNodes();
        else {   if (dependencyToDelete == null)
        {
            throw new DalDoesNotExistException($"dependency with ID={id} does not exist");
        }
        else
        {
            dependencyToDelete.Remove();
            dependencysElements?.Save(DependencysFile);
        } }
     
    }

    public Dependency? Read(int id)
    {
        XElement? dependencysElements = XDocument.Load(DependencysFile).Root;

        if (dependencysElements != null)
        {
            XElement? dependencyElement = dependencysElements.Elements("Dependency")
                .FirstOrDefault(dependency => Convert.ToInt32(dependency.Element("Id")?.Value) == id);
            if (dependencyElement != null)
            {
                Dependency dp = new Dependency
                (
                    Convert.ToInt32(dependencyElement.Element("Id")?.Value),
                    Convert.ToInt32(dependencyElement.Element("DependentTask")!.Value),
                    Convert.ToInt32(dependencyElement.Element("DependsOnTask")?.Value)
                );
                return dp;
            }
        }
        return null;
    }

    public Dependency? Read(Func<Dependency, bool> filter)
    {
        XElement? dependencysElements = XDocument.Load(DependencysFile).Root;

        if (dependencysElements != null)
        {
            XElement? dependencyElement = dependencysElements.Elements("Dependency")
                .FirstOrDefault(dependency => filter(ConvertDependencyFromXElement(dependency)));

            if (dependencyElement != null)
            {
                Dependency dp = new Dependency
                (
                    Convert.ToInt32(dependencyElement.Element("Id")?.Value),
                    Convert.ToInt32(dependencyElement.Element("DependentTask")!.Value),
                    Convert.ToInt32(dependencyElement.Element("DependsOnTask")?.Value)
                );
                return dp;
            }
        }
        return null;
    }

    private Dependency ConvertDependencyFromXElement(XElement element)
    {
        // Implement the conversion logic from XElement to Dependency here
        return new Dependency(
            Convert.ToInt32(element.Element("Id")?.Value),
            Convert.ToInt32(element.Element("DependentTask")!.Value),
            Convert.ToInt32(element.Element("DependsOnTask")?.Value)
        );
    }

    public IEnumerable<Dependency?> ReadAll(Func<Dependency, bool>? filter = null)
    {
        XElement? dependencysElements = XDocument.Load(DependencysFile).Root;
        if (dependencysElements != null)
        {
            IEnumerable<Dependency> allDependencys = dependencysElements.Elements("Dependency").Select(dependencyElement => new Dependency(
            Convert.ToInt32(dependencyElement.Element("Id")?.Value),
            Convert.ToInt32(dependencyElement.Element("DependentTask")!.Value),
            Convert.ToInt32(dependencyElement.Element("DependsOnTask")?.Value)
        ));
            if (filter != null)
            {
                return allDependencys.Where(filter);
            }

            return allDependencys;
        }
        return Enumerable.Empty<Dependency>();
    }


    public void Update(Dependency item)
    {
        XElement? dependencysElements = XDocument.Load(DependencysFile).Root;
        XElement? dependencyToUpdate = dependencysElements?.Elements().FirstOrDefault(dependency => Convert.ToInt32(dependency?.Element("Id")?.Value) == item.Id);

        if (dependencyToUpdate != null)
        {
            Delete(item.Id);
            XElement newDependencyElement = new XElement("Dependency",
             new XElement("Id", item.Id),
             new XElement("DependentTask", item.DependentTask),
             new XElement("DependsOnTask", item.DependsOnTask));
            dependencysElements?.Add(newDependencyElement);
            dependencysElements?.Save(DependencysFile);
        }
    }
}

