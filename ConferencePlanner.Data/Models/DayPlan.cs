using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Data.Models
{
    public class DayPlan
    {
        //1.1
        public List<Activity> Activities { get; set; }
        public DayPlan(List<Activity> activities)
        {
            Activities = activities;
        }

        //1.0
        //public double TotalDuration { get; set; }
        //public List<ActivityStruct> MorningActivities { get; set; }
        //public List<ActivityStruct> AfternoonActivities { get; set; }

        //public DayPlan(List<ActivityStruct> morningActivities, List<ActivityStruct> afternoonActivities, double totalDuration = 0.0)
        //{
        //    MorningActivities = morningActivities;
        //    AfternoonActivities = afternoonActivities;
        //    TotalDuration = totalDuration;
        //}
    }
}
