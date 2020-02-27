using ConferencePlanner.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Data.Models
{
    public interface IActivityData
    {
        List<Activity> GetAll();
        List<Activity> CreatePlan(string source = "");
        Activity GetById(int id);
        Activity Add(Activity newActivity);
        Activity Update(Activity updatedActivity);
        Activity Delete(int id);
        int Commit();
    }
}
