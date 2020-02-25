using ConferencePlanner.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Data.Contexts
{
    public class ConferencePlannerDbContext : DbContext
    {
        public ConferencePlannerDbContext(DbContextOptions<ConferencePlannerDbContext> options) : base(options)
        {

        }
        public DbSet<Activity> Activities { get; set; }
    }
}
