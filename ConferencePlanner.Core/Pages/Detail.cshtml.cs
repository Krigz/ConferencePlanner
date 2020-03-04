using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConferencePlanner.Core
{
    public class DetailModel : PageModel
    {
        private readonly IActivityData _activityData;

        [TempData]
        public string Message { get; set; }
        public Activity Activity { get; set; }

        public DetailModel(IActivityData activityData)
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
    }
}