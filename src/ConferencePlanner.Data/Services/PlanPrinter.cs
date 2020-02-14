using ConferencePlanner.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Data.Services
{
    public class PlanPrinter
    {
        public void PrintPlan(DayPlan dayPlan)
        {
            dayPlan.MorningActivities.ForEach(PrintSingleActivity);
            Console.WriteLine("One hour lunch break");
            dayPlan.AfternoonActivities.ForEach(PrintSingleActivity);
            Console.WriteLine($"Total day duration: {dayPlan.TotalDuration.ToString()}h");
        }
        public void PrintPlan(List<ActivityStruct> activities)
        {
            activities.ForEach(PrintSingleActivity);
        }

        public void PrintSingleActivity(ActivityStruct activity)
        {
            Console.WriteLine($"Activity (duration): {activity.Name} ({activity.Duration}h)");
        }
    }
}
