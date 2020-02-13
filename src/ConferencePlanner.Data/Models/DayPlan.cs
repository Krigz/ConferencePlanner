using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Data.Models
{
    public class DayPlan
    {
        public double TotalDuration { get; set; }
        public List<Activity> MorningActivities { get; set; }
        public List<Activity> AfternoonActivities { get; set; }

        public DayPlan(List<Activity> morningActivities, List<Activity> afternoonActivities, double totalDuration = 0.0)
        {
            MorningActivities = morningActivities;
            AfternoonActivities = afternoonActivities;
            TotalDuration = totalDuration;
        }
    }
}
