namespace ConferencePlanner.Output
{
    class Program
    {
        static void Main(string[] args)
        {
            string bestand = "ConferencePlanner3.txt";

            var planLezer = new PlanLezer();
            var plan = planLezer.PlanLezen(bestand, "-");

            DagPlanner dagPlanner = new DagPlanner();
            dagPlanner.DagPlannen(plan);
        }
    }
}
