using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConferencePlanner.Data.Models;

namespace ConferencePlanner.Data.Services
{
    public class DagPlanner
    {
        double dagTotaal = 0;
        List<string> dagActiviteiten = new List<string>();
        List<string> dagDuurActiviteiten = new List<string>();
        List<string> voormiddagActiviteiten = new List<string>();
        List<string> namiddagActiviteiten = new List<string>();
        //List<Activiteit> voormiddag = new List<Activiteit>();
        //List<Activiteit> namiddag = new List<Activiteit>();

        public void DagPlannen(List<Activiteit> activiteiten)
        {
            List<Activiteit> activiteitenVolgensDuur = activiteiten.OrderBy(order => order.Duur).ToList();
            //Console.WriteLine(activiteiten);

            for (int i = 0; i < activiteitenVolgensDuur.Count; i++)
            {
                double nieuweActiviteit = activiteitenVolgensDuur[i].Duur;

                if (dagTotaal + nieuweActiviteit <= 8)
                {
                    if (dagTotaal + nieuweActiviteit < 5)
                    {
                        //voormiddag.Add(activiteitenVolgensDuur[i]);
                        voormiddagActiviteiten.Add($"{activiteitenVolgensDuur[i].Naam} ({nieuweActiviteit.ToString()}u)");
                    }
                    else
                    {
                        //namiddag.Add(activiteitenVolgensDuur[i]);
                        namiddagActiviteiten.Add($"{activiteitenVolgensDuur[i].Naam} ({nieuweActiviteit.ToString()}u)");
                    }

                    dagActiviteiten.Add(activiteitenVolgensDuur[i].Naam);
                    dagDuurActiviteiten.Add(nieuweActiviteit.ToString() + "u");

                    dagTotaal += nieuweActiviteit;
                }
            }

            Console.WriteLine("Dagactiviteiten: " + string.Join(", ", dagActiviteiten));
            Console.WriteLine("Dagactiviteiten duur: " + string.Join(", ", dagDuurActiviteiten));
            Console.WriteLine("Dagplanning: " + dagTotaal + "u");
            Console.WriteLine("Voormiddag: " + string.Join(", ", voormiddagActiviteiten));
            Console.WriteLine("Namiddag: " + string.Join(", ", namiddagActiviteiten));

            // return dagPlan(voormiddag, namiddag);
        }

        public void DagPlannen(PlanLezer plan) { }
    }
}
