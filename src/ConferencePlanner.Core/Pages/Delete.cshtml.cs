using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConferencePlanner.Core
{
    public class DeleteModel : PageModel
    {
        private readonly IActivityData _activityData;
        [TempData]
        public string Message { get; set; }
        public Activity Activity { get; set; }

        public DeleteModel(IActivityData activityData)
        {
            _activityData = activityData;
        }
        public IActionResult OnGet(int activityId)
        {
            Activity = _activityData.GetById(activityId);
            if (Activity == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int activityId)
        {
            var activity = _activityData.Delete(activityId);
            _activityData.Commit();

            if (activity == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"The action '{activity.Name}' was successfully deleted.";
            return RedirectToPage("./Index");
        }
    }
}