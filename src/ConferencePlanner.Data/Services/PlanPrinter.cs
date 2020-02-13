using ConferencePlanner.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Data.Services
{
    public class PlanPrinter
    {
        public void PrintPlan(List<Activity> activities)
        {
            activities.ForEach(PrintSingleActivity);
        }

        public void PrintSingleActivity(Activity activity)
        {
            Console.WriteLine($"Activity (duration): {activity.Name} ({activity.Duration}h)");
        }
    }
}
