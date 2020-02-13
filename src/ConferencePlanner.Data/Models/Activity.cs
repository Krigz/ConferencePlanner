using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Data.Models
{
    public class Activity
    {
        public Activity(string name, double duration)
        {
            Name = name;
            Duration = duration;
        }

        public string Name
        {
            get; set;
        }
        public double Duration
        {
            get; set;
        }
    }
}
