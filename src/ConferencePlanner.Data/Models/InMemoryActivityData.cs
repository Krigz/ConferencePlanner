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

        public List<Activity> GetAll()
        {
            return activities.OrderBy(a => a.Duration).ToList();
        }

        public Activity GetById(int id)
        {
            return activities.SingleOrDefault(r => r.Id == id);
        }

        public List<Activity> CreatePlan(string source = null)
        {
            var plan = new DayPlanner();
            return plan.PlanDay(activities);
        }

        public Activity Add(Activity newActivity)
        {
            activities.Add(newActivity);
            newActivity.Id = activities.Max(a => a.Id) + 1;
            return newActivity;
        }

        public Activity Update(Activity updatedActivity)
        {
            var activity = activities.SingleOrDefault(r => r.Id == updatedActivity.Id);

            if (activity != null)
            {
                activity.Name = updatedActivity.Name;
                activity.Duration = updatedActivity.Duration;
                activity.Description = updatedActivity.Description;
            }

            return activity;
        }

        public Activity Delete(int id)
        {
            var activity = activities.SingleOrDefault(a => a.Id == id);
            if (activity != null)
            {
                activities.Remove(activity);
            }

            return activity;
        }

        public int Commit()
        {
            return 0;
        }
    }
}
