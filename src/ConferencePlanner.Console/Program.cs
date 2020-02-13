using ConferencePlanner.Data.Services;

namespace ConferencePlanner.Output
{
    class Program
    {
        static void Main(string[] args)
        {
            string bestand = "ConferencePlanner3.txt";

            var planReader = new PlanReader();
            var plan = planReader.ReadPlan(bestand, "-");

            var dayPlanner = new DayPlanner();
            dayPlanner.PlanDay(plan);

            var planPrinter = new PlanPrinter();
            planPrinter.PrintPlan(plan);
        }
    }
}
