using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// Qualities of an Task
    /// </summary>
  
    public class Task
    {
        public int Id { get; init; }
        public string? Description { get; set; }
        public string? Alias { get; set; }
        public MilestoneInTask? Milestone { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CreatedAtDate { get; set; }
        public DateTime? BaselineStartDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ForecastDate { get; set; }
        public DateTime ?DeadlineDate { get; set; }
        public DateTime ?CompleteDate { get; set; }
        public string? Deliverables { get; set; }
        public string   ? Remarks { get; set; }
        public List<TaskInList>? Dependencies { get; set; } // List of dependent tasks
       public EngineerInTask? Engineer { get; set; }
        public EngineerExperience ComplexityLevel { get; set; }

        public override string ToString() => this.ToStringProperty();
    }
}
