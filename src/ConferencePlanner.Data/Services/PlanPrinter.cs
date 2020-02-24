using ConferencePlanner.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Data.Services
{
    public class PlanPrinter
    {
        public void PrintPlanToConsole(DayPlan dayPlan)
        {
            dayPlan.MorningActivities.ForEach(PrintSingleActivityToConsole);
            Console.WriteLine("One hour lunch break");
            dayPlan.AfternoonActivities.ForEach(PrintSingleActivityToConsole);
            Console.WriteLine($"Total day duration: {dayPlan.TotalDuration.ToString()}h");
        }

        public void PrintPlanToWebPage(DayPlan dayPlan)
        {
            // todo
            string[] morningActivities = new string[dayPlan.MorningActivities.Count];
            string[] afternoonActivities = new string[dayPlan.AfternoonActivities.Count];
            var index = 0;

            foreach (var morningActivity in dayPlan.MorningActivities)
            {
                morningActivities[index] = morningActivity.ToString();
                index++;
            }
            index = 0;
            foreach (var afternoonActivity in dayPlan.AfternoonActivities)
            {
                morningActivities[index] = afternoonActivity.ToString();
                index++;
            }

            string[] allActivities = new string[morningActivities.Length + afternoonActivities.Length + 1];
            Array.Copy(morningActivities, allActivities, morningActivities.Length);
            Array.Copy(new string[] { "Lunch break", "1" }, allActivities, 1);
            Array.Copy(afternoonActivities, allActivities, afternoonActivities.Length);
            
        }

        public void PrintPlanToConsole(List<ActivityStruct> activities)
        {
            activities.ForEach(PrintSingleActivityToConsole);
        }

        public void PrintSingleActivityToConsole(ActivityStruct activity)
        {
            Console.WriteLine($"Activity (duration): {activity.Name} ({activity.Duration}h)");
        }
    }
}
