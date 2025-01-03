﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    /// <summary>
    /// Interface for a task
    /// </summary>
    public interface ITask
    {
        public int Create(BO.Task item);
        public BO.Task? Read(int id);
        public IEnumerable<BO.Task> ReadAll(Func<BO.Task, bool>? filter = null);
        public void Update(BO.Task item);
        //public void Delete(int id);
     
    }

}
