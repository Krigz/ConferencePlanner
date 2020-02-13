using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ConferencePlanner.Data.Models;

namespace ConferencePlanner.Data.Services
{
    public class PlanReader
    {
        public List<Activity> ReadPlan(string path, string separator = "-")
        {
            List<Activity> activities = new List<Activity>();

            try
            {
                using (var content = File.OpenText(path))
                {
                    string activityString = content.ReadLine();

                    while (activityString != null)
                    {
                        try
                        {
                            string[] temp = activityString.Split(separator);
                            var activity = new Activity(temp[0].Trim(), double.Parse(temp[1].Replace(".", ",")));
                            activities.Add(activity);

                            //Console.WriteLine($"{activity.Name} ({activity.Duration}h)");
                            activityString = content.ReadLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Separator \"{separator}\" not found.");
                            throw ex;
                        }
                    }
                }

                return activities;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found.");
                throw ex;
            }
        }
    }
}
