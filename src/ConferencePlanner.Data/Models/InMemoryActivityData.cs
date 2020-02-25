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
                new Activity { Id = 1, Name = "Shopping", Duration = 1.5 },
                new Activity { Id = 2, Name = "Cleaning", Duration = 1 },
                new Activity { Id = 3, Name = "Napping 1", Duration = 0.5 },
                new Activity { Id = 4, Name = "Gardening", Duration = 1 },
                new Activity { Id = 5, Name = "Cooking", Duration = 1.5 },
                new Activity { Id = 6, Name = "Napping 2", Duration = 0.5 },
                new Activity { Id = 7, Name = "Relaxing", Duration = 1.5 },
                new Activity { Id = 8, Name = "Eating", Duration = 0.5 },
                new Activity { Id = 9, Name = "Napping 3", Duration = 0.5 }
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
