using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi;
public interface IMilestone
{
    /// <summary>
    /// Creating the milestone project schedule
    /// </summary>
    public void CreateProjectSchedule();
    /// <summary>
    /// read Milestone
    /// </summary>
    /// <param name="id">id of Milestone to read</param>
    /// <returns>A Milestone</returns>
    public BO.Milestone? Read(int id);
    /// <summary>
    /// Update Milestone
    /// </summary>
    /// <param name="milestone">Milestone to update</param>
    /// <returns>A Milestone</returns>
    public BO.Milestone? Update(Milestone milestone);
}