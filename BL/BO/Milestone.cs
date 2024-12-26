using System;
using System.Collections.Generic;

namespace BO
{
    /// <summary>
    /// Qualities of an Milestone
    /// </summary>
    public class Milestone
    {
        public int Id { get; init; }
        public string? Description { get; set; }
        public string? Alias { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CreatedAtDate { get; set; }
        // DateTime BaselineStartDate; // Commented out as it's not used
        public DateTime? StartDate { get; set; }
        // DateTime ScheduledDate; // Commented out as it's not used
        public DateTime? ForecastDate { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public DateTime? CompleteDate { get; set; }
        public double CompletionPercentage { get; set; }
        public string? Remarks { get; set; }
        public IEnumerable<BO.TaskInList> Dependencies { get; set; }

        public override string ToString() => this.ToStringProperty();
    }

   
}
