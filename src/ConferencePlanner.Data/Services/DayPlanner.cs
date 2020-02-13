using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConferencePlanner.Data.Models;

namespace ConferencePlanner.Data.Services
{
    public class DayPlanner
    {
        public DayPlan PlanDay(List<Activity> activities)
        {
            List<Activity> activitiesByDuration = activities.OrderBy(order => order.Duration).ToList();
            List<Activity> morningActivities = new List<Activity>();
            List<Activity> afternoonActivities = new List<Activity>();
            double totalDayDuration = 0;

            foreach (var activity in activitiesByDuration)
            {
                double newActivityDuration = activity.Duration;

                if (totalDayDuration + newActivityDuration > 8)
                    continue;

                if (totalDayDuration + newActivityDuration < 5)
                {
                    morningActivities.Add(activity);
                }
                else
                {
                    afternoonActivities.Add(activity);
                }

                totalDayDuration += newActivityDuration;
                
            }

            var dayPlan = new DayPlan(morningActivities, afternoonActivities, totalDayDuration);
            return dayPlan;
        }

        public void PlanDay(PlanReader plan) { }
    }
}
