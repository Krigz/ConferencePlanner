using ConferencePlanner.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Data.Services
{
    public class PlanPrinter
    {
        public void PrintPlanToConsole(IEnumerable<Activity> activities)
        {
            //1.1
            var totalDuration = 0.0;

            foreach (var activity in activities)
            {
                Console.WriteLine($"{activity.Name} ({activity.Duration})");
                totalDuration += activity.Duration;
            }

            //1.0
            //dayPlan.MorningActivities.ForEach(PrintSingleActivityToConsole);
            //Console.WriteLine("One hour lunch break");
            //dayPlan.AfternoonActivities.ForEach(PrintSingleActivityToConsole);
            //Console.WriteLine($"Total day duration: {dayPlan.TotalDuration.ToString()}h");
        }

        public void PrintPlanToConsole(List<Activity> activities)
        {
            activities.ForEach(PrintSingleActivityToConsole);
        }

        public void PrintSingleActivityToConsole(Activity activity)
        {
            Console.WriteLine($"Activity (duration): {activity.Name} ({activity.Duration}h)");
        }
    }
}
