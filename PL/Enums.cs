using System;
using System.Collections;
using System.Collections.Generic;

namespace PL
{
    // This class represents a collection of engineer experience levels
    internal class EngineersCollection : IEnumerable
    {
        // Static readonly field holding the engineer experience levels
        static readonly IEnumerable<BO.EngineerExperience> s_enums =
            (Enum.GetValues(typeof(BO.EngineerExperience)) as IEnumerable<BO.EngineerExperience>)!;

        // GetEnumerator method for iterating through the engineer experience levels
        public IEnumerator GetEnumerator() => s_enums.GetEnumerator();
    }

    // This class represents a collection of task statuses
    internal class TaskStatusCollection : IEnumerable
    {
        // Static readonly field holding the task statuses
        static readonly IEnumerable<BO.TaskStatus> s_enums =
            (Enum.GetValues(typeof(BO.TaskStatus)) as IEnumerable<BO.TaskStatus>)!;

        // GetEnumerator method for iterating through the task statuses
        public IEnumerator GetEnumerator() => s_enums.GetEnumerator();
    }
}
