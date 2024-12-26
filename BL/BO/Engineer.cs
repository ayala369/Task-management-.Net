using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// Qualities of an engineer
    /// </summary>
    /// 
    /// <param name="Id">Id of the engineer</param>
    /// <param name="Name">Name of the engineer</param>
    /// <param name="Email">Email of the engineer</param>
    /// <param name="Level">Level of the engineer</param>
    /// <param name="Cost">Cost of the engineer</param>
    /// <param name="Task">tasks of the engineer</param>
    public class Engineer
    {
 public int Id { get; init; }
        public string? Name { get; set; } 
        public string? Email { get; set; }
        public EngineerExperience? Level { get; set; }
        public double? Cost { get; set; }
        public TaskInEngineer? Task { get; set; }

       public override string ToString() => this.ToStringProperty();
    }
    }

