using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// Qualities of an TaskInEngineer
    /// </summary>
    public class TaskInEngineer
    {
        public int Id { get; init; }
        public string? Alias { get; set; }
        public override string ToString() => this.ToStringProperty();
    }
}
