using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// Qualities of an engineerInTask
    /// </summary>
    ///     /// <param name="Id">Id of the engineer</param>
    /// <param name="Name">Name of the engineer</param>
    public class EngineerInTask
    {
        
        public int Id { get; init; }
        public string? Name { get; set; }
        public override string ToString() => this.ToStringProperty();
    }
}
