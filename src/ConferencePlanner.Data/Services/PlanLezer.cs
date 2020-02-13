using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ConferencePlanner.Data.Models;

namespace ConferencePlanner.Data.Services
{
    public class PlanLezer
    {
        public List<Activiteit> PlanLezen(string pad, string separator = "-")
        {
            List<Activiteit> activiteiten = new List<Activiteit>();

            try
            {
                using (var inhoud = File.OpenText(pad))
                {
                    string activiteitString = inhoud.ReadLine();

                    while (activiteitString != null) // dubbele check if :(
                    {
                        Activiteit activiteit = new Activiteit();
                        try
                        {
                            string[] temp = activiteitString.Split(separator);
                            activiteit.Naam = temp[0].Trim();
                            activiteit.Duur = double.Parse(temp[1].Replace(".", ","));
                            activiteiten.Add(activiteit);

                            Console.WriteLine($"{activiteit.Naam} ({activiteit.Duur}u)");
                            activiteitString = inhoud.ReadLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Scheidingskarakter \"{separator}\" werd niet gevonden.");
                            throw ex;
                        }
                    }
                }

                return activiteiten;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found.");
                throw ex;
            }
        }
    }
}
