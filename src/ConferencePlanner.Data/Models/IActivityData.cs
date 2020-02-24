using ConferencePlanner.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConferencePlanner.Data
{
    public interface IActivityData
    {
        IEnumerable<ActivityStruct> GetAll();
    }

    public class InMemoryActivityData : IActivityData
    {
        readonly List<ActivityStruct> activities;
        public InMemoryActivityData()
        {
            activities = new List<ActivityStruct>()
            { 
                new ActivityStruct { Name = "Shopping", Duration = 1.5 },
                new ActivityStruct { Name = "Cleaning", Duration = 1 },
                new ActivityStruct { Name = "Gardening", Duration = 1 },
                new ActivityStruct { Name = "Cooking", Duration = 1.5 },
                new ActivityStruct { Name = "Relaxing", Duration = 1.5 },
                new ActivityStruct { Name = "Eating", Duration = 0.5 }
            };
        }
        public IEnumerable<ActivityStruct> GetAll()
        {
            return from a in activities
                   orderby a.Duration
                   select a;
        }
    }
}
