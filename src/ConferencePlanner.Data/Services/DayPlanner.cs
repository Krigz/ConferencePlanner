using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConferencePlanner.Data.Models;

namespace ConferencePlanner.Data.Services
{
    public class DayPlanner
    {
        private List<ActivityStruct> _remainingActivities = new List<ActivityStruct>();
        private readonly List<ActivityStruct> _morningActivities = new List<ActivityStruct>();
        private readonly List<ActivityStruct> _afternoonActivities = new List<ActivityStruct>();
        private double _totalDayDuration = 0.0;
        private const double _maxDayDuration = 8.0;

        public DayPlan PlanDay(List<ActivityStruct> activities)
        {
            //_activitiesByDuration = activities.OrderBy(order => order.Duration).ToList();

            _remainingActivities = activities.Reverse<ActivityStruct>().ToList(); // reverse here, to reverse again later in 'foreach'

            foreach (var activity in _remainingActivities.Reverse<ActivityStruct>()) // reversed again
            {
                if ((_totalDayDuration + activity.Duration) <= _maxDayDuration)
                {
                    if ((_totalDayDuration + activity.Duration) <= 5)
                    {
                        _morningActivities.Add(activity);
                    }
                    else
                    {
                        _afternoonActivities.Add(activity);
                    }
                    //Console.WriteLine($"added: {activity.Name}");
                    _totalDayDuration += activity.Duration;
                    //Console.WriteLine($"total duration: {_totalDayDuration}");
                    _remainingActivities.Remove(activity);

                }
                else
                {
                    continue;
                }   
            }

            var dayPlan = new DayPlan(_morningActivities, _afternoonActivities, _totalDayDuration);
            return dayPlan;
        }

        public void PlanDay(PlanReader plan) { }
    }
}
