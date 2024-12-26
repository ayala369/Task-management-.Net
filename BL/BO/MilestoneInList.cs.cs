using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 /// <summary>
     /// Qualities of an MilestoneInList
     /// </summary>
namespace BO
{   
    public class MilestoneInList
    {
        //public int Id { get; init; }
        public string? Description { get; set; }
        public string? Alias { get; set; }
        public DateTime CreatedAtDate { get; set; }
        public TaskStatus Status { get; set; }
        public double CompletionPercentage { get; set; }

        public override string ToString() => this.ToStringProperty();
    }

}
