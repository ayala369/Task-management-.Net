
namespace DO;
/// <summary>
/// /// Defining the attributes of the task entity 
/// </summary>
/// <param name="Id"></param>
/// <param name="Description"></param>
/// <param name="Alias"></param>
/// <param name="Engineerld"></param>
/// <param name="Milestone"></param>
/// <param name="CreatedAt"></param>
/// <param name="Start"></param>
/// <param name="ScheduledDate"></param>
/// <param name="ForecastDast"></param>
/// <param name="Deadline"></param>
/// <param name="Complete"></param>
/// <param name="Deliverables"></param>
/// <param name="Remarks"></param>
/// <param name="ComplexityLevel"></param>
public record Task
(
   int Id,
   string? Description,
   string Alias,
   int? Engineerld,
   bool Milestone =false,
   TimeSpan? RequiredEffortTime = null,
   DateTime CreatedAt=new DateTime(),
   DateTime? Start = null,
   DateTime? ScheduledDate = null,
   DateTime? Deadline = null,
   DateTime? Complete = null,
   string? Deliverables = null,
   string? Remarks = null,
   EngineerExperience? ComplexityLevel = null
)

{
    public Task() : this(0, "", "",0, false) { }
}