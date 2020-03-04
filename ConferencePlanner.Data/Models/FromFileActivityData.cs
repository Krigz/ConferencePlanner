using ConferencePlanner.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferencePlanner.Data.Models
{
    public class FromFileActivityData : IActivityData
    {
        public List<Activity> activities;

        public FromFileActivityData()
        {
            ReadFromFile(@"..\ConferencePlanner.Console\bin\Debug\netcoreapp3.1\ConferencePlanner.txt");
        }
        private void ReadFromFile(string path)
        {
            var activitiesFromFile = new PlanReader();
            activities = activitiesFromFile.ReadPlan(path);
            foreach (Activity activity in activities)
            {
                activity.Id = activities.IndexOf(activity) + 1;
            }
        }
        public Activity Add(Activity newActivity)
        {
            throw new NotImplementedException();
        }

        public List<Activity> CreatePlan(string source = "")
        {
            var planFromFile = new DayPlanner();
            return planFromFile.PlanDay(activities);
        }

        public Activity Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Activity> GetAll()
        {
            return activities;
        }

        public Activity GetById(int id)
        {
            return activities.SingleOrDefault(a => a.Id == id);
        }

        public Activity Update(Activity updatedActivity)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }
    }
}
