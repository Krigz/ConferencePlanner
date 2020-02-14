using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Data.Models
{
    public struct ActivityStruct
    {
        public ActivityStruct(string name, double duration)
        {
            Name = name;
            Duration = duration;
        }

        public string Name;
        public double Duration;
    }
}
