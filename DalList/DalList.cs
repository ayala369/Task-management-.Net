using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dal;
using DalApi;
using System.Diagnostics;

sealed internal class DalList : IDal
{
    public static IDal Instance { get; } = new DalList();
    private DalList() { }

    public IEngineer Engineer => new EngineerImplementation();

    public ITask Task => new TaskImplementation();

    public IDependency Dependency => new DependencyImplementation();
    public void Reset()
    {
        Task.Delete();
        Engineer.Delete();
        Dependency.Delete();
    }
    public DateTime? ProjectStartDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTime? ProjectEndDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
