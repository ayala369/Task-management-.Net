
namespace DO;
/// <summary>
/// Defining the attributes of the Dependency entity 
/// </summary>
/// <param name="Id">Id of the Dependency</param>
/// <param name="DependentTask">ID number of pending task</param>
/// <param name="DependsOnTask">ID number of pending task</param>
public record Dependency
(
    int Id,
 int DependentTask,
 int DependsOnTask
)
{
    public Dependency() : this(0, 0, 0) { }
}
