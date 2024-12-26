using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// Qualities of an TaskInList
    /// </summary>
    public class TaskInList
    {
        public int Id { get; init; }
        public string? Description { get; set; }
        public string? Alias { get; set; }
        public TaskStatus Status { get; set; }
        public override string ToString() => this.ToStringProperty();
    }
}
