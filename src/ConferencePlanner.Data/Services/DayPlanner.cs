using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConferencePlanner.Data.Models;

namespace ConferencePlanner.Data.Services
{
    public class DayPlanner
    {
        private List<Activity> _activitiesByDuration = new List<Activity>();
        private List<Activity> _morningActivities = new List<Activity>();
        private List<Activity> _afternoonActivities = new List<Activity>();
        private double _totalDayDuration = 0.0;

        public DayPlan PlanDay(List<Activity> activities)
        {
            _activitiesByDuration = activities.OrderBy(order => order.Duration).ToList();

            foreach (var activity in _activitiesByDuration)
            {
                double newActivityDuration = activity.Duration;

                if (_totalDayDuration + newActivityDuration > 8)
                    continue;

                if (_totalDayDuration + newActivityDuration < 5)
                {
                    _morningActivities.Add(activity);
                }
                else
                {
                    _afternoonActivities.Add(activity);
                }

                _totalDayDuration += newActivityDuration;
                
            }

            var dayPlan = new DayPlan(_morningActivities, _afternoonActivities, _totalDayDuration);
            return dayPlan;
        }

        public void PlanDay(PlanReader plan) { }
    }
}
