using ConferencePlanner.Data.Services;

namespace ConferencePlanner.Output
{
    class Program
    {
        static void Main(string[] args)
        {
            var bestand = "ConferencePlanner.txt";

            var planReader = new PlanReader();
            var plan = planReader.ReadPlan(bestand, "-");

            var dayPlanner = new DayPlanner();
            var dayPlan = dayPlanner.PlanDay(plan);

            var planPrinter = new PlanPrinter();
            planPrinter.PrintPlanToConsole(dayPlan);
        }
    }
}
