using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Qualities of an MilestoneInTask
/// </summary>
namespace BO
{
    public class MilestoneInTask
    {
        public int Id { get; init; }
        public string? Alias { get; set; }
        public override string ToString() => this.ToStringProperty();

    }
}
