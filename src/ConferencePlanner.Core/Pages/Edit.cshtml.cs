using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConferencePlanner.Core
{
    public class EditModel : PageModel
    {
        private readonly IActivityData _activityData;
        
        [BindProperty] // to make the restaurant both output (OnGet) and input (OnPost)
        public Activity Activity { get; set; }

        public EditModel(IActivityData activityData)
        {
            _activityData = activityData;
        }

        public IActionResult OnGet(int? activityId)
        {
            if (activityId.HasValue)
            {
                Activity = _activityData.GetById(activityId.Value);
            }
            else
            {
                Activity = new Activity();
            }

            if (Activity == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) // check the ModelState (also for checking attempted inputs etc.)
            {
                return Page();
            }

            if (Activity.Id > 0)
            {
                _activityData.Update(Activity);
            }
            else
            {
                _activityData.Add(Activity);
            }

            _activityData.Commit();
            TempData["Message"] = "Activity saved.";
            return RedirectToPage("./Detail", new { activityId = Activity.Id });
        }
    }
}