using ConferencePlanner.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Data.Models
{
    public interface IActivityData
    {
        IEnumerable<Activity> GetAll(string source = "");
        IEnumerable<Activity> CreatePlan(string source = "");
    }
}
