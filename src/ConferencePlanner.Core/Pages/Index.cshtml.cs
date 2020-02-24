using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.Data;
using ConferencePlanner.Data.Models;
using ConferencePlanner.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ConferencePlanner.Core.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IActivityData _activityData;

        public string Message { get; set; }
        public IEnumerable<ActivityStruct> Activities { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IActivityData activityData)
        {
            _logger = logger;
            _activityData = activityData;
        }

        public void OnGet()
        {
            var bestand = "..\\ConferencePlanner.Console\\bin\\Debug\\netcoreapp3.1\\ConferencePlanner.txt";
            Activities = _activityData.GetAll();
        }
    }
}
