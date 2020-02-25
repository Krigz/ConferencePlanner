using ConferencePlanner.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Data.Entities
{
    public class ConferencePlannerDbContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
    }
}
