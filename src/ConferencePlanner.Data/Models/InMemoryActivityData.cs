using ConferencePlanner.Data.Models;
using ConferencePlanner.Data.Services;
using System.Collections.Generic;
using System.Linq;

namespace ConferencePlanner.Data.Models
{
    public class InMemoryActivityData : IActivityData
    {
        readonly List<Activity> activities;
        public InMemoryActivityData()
        {
            activities = new List<Activity>()
            { 
                new Activity { Name = "Shopping", Duration = 1.5 },
                new Activity { Name = "Cleaning", Duration = 1 },
                new Activity { Name = "Napping 1", Duration = 0.5 },
                new Activity { Name = "Gardening", Duration = 1 },
                new Activity { Name = "Cooking", Duration = 1.5 },
                new Activity { Name = "Napping 2", Duration = 0.5 },
                new Activity { Name = "Relaxing", Duration = 1.5 },
                new Activity { Name = "Eating", Duration = 0.5 },
                new Activity { Name = "Napping 3", Duration = 0.5 }
            };
        }

        public IEnumerable<Activity> CreatePlan(string source = null)
        {
            var plan = new DayPlanner();
            return plan.PlanDay(activities);
        }

        public IEnumerable<Activity> GetAll(string source = null)
        {
            return from a in activities
                   orderby a.Duration
                   select a;
        }
    }
}
