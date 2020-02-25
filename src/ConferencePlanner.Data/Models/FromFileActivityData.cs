using ConferencePlanner.Data.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Data.Models
{
    public class FromFileActivityData : IActivityData
    {
        public IEnumerable<Activity> CreatePlan(string source = "")
        {
            var activitiesFromFile = new PlanReader();
            activitiesFromFile.ReadPlan(source);

            var planFromFile = new DayPlanner();
            return planFromFile.PlanDay(activitiesFromFile.ReadPlan(source));
        }

        public IEnumerable<Activity> GetAll(string source)
        {
            var fromFilePlan = new PlanReader();
            return fromFilePlan.ReadPlan(source);
        }
    }
}
