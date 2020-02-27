using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConferencePlanner.Data.Models
{
    public class Activity
    {
        public Activity()
        {
        }
        public Activity(string name, double duration = 0.5, string description = "") // for DbSet usage
        //public Activity(string name, double duration) // default setup
        {
            Name = name;
            Duration = duration;
            Description = description;
        }
        public int Id { get; set; }
        [Required, MaxLength(80)]
        public string Name { get; set; }
        [Required, Range(0.01, 5)]
        public double Duration { get; set; }
        public string Description { get; set; }
    }
}
