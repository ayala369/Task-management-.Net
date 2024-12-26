using DalApi;
using System.Diagnostics;

namespace Dal;
//stage 3
sealed internal class DalXml : IDal
{
    public static IDal Instance { get; } = new DalXml();
    private DalXml() { }
    public ITask Task => new TaskImplementation();
    public IEngineer Engineer => new EngineerImplementation();
    public IDependency Dependency => new DependencyImplementation();
    public void Reset()
    {
        Task.Delete();
        Engineer.Delete();
        Dependency.Delete();
    }
    public DateTime? ProjectStartDate
    {
        get => XMLTools.GetDateFromConfig("data-config", "ProjectStartDate");
        set
        { XMLTools.SetDateFromConfig("data-config", "ProjectStartDate", value); }
    }
    public DateTime? ProjectEndDate
    {
        get => XMLTools.GetDateFromConfig("data-config", "ProjectEndDate");
        set
        { XMLTools.SetDateFromConfig("data-config", "ProjectEndDate", value); }
    }
}