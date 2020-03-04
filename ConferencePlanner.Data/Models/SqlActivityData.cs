using ConferencePlanner.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConferencePlanner.Data.Models
{
    public class SqlActivityData : IActivityData
    {
        private readonly ConferencePlannerDbContext _db;

        public SqlActivityData(ConferencePlannerDbContext db)
        {
            _db = db;
        }

        public Activity Add(Activity newActivity)
        {
            //_db.Activities.Add // EF is smart enough to recognize the object type
            _db.Add(newActivity);
            return newActivity; // only because we need to return a value from the contract
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public List<Activity> CreatePlan(string source = "")
        {
            var activities = GetAll();
            var result = new List<Activity>();
            var duration = 0.0;
            foreach (var activity in activities)
            {
                if ((duration + activity.Duration) <= 8)
                {
                    duration += activity.Duration;
                    result.Add(activity);
                }
                
            }
            return result;
        }

        public Activity Delete(int id)
        {
            var activity = GetById(id);
            if (activity != null)
            {
                _db.Remove(activity);
            }
            return activity;
        }

        public List<Activity> GetAll()
        {
            var query = _db.Activities.OrderBy(a => a.Duration).ToList();
            return query;
        }

        public Activity GetById(int id)
        {
            return _db.Activities.Find(id);
        }

        public Activity Update(Activity updatedActivity)
        {
            var entity = _db.Activities.Attach(updatedActivity); // give the EF an object that is already in the db to track changes
            entity.State = EntityState.Modified; // tell EF that everything has changed except the id
            return updatedActivity;
        }
    }
}
