﻿using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{/// <summary>
/// Interface for all dal
/// </summary>
    public interface IDal
    {
        IEngineer Engineer { get; }
        ITask Task { get; }
        IDependency Dependency { get; }
        public void Reset();
        DateTime? ProjectStartDate { get; set; }
        DateTime? ProjectEndDate { get; set; }
    }
}
