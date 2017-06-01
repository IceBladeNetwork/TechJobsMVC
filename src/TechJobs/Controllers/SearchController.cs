using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        [HttpGet]
        [Route("Views/Search/Results?searchType=[searchType]&searchTerm=[searchTerm]")]
        public IActionResult Results(string searchType, string searchTerm)
        {
            // List<Dictionary<String, String>> jobs = JobData.FindByValue(searchTerm);
            ViewBag.title = "Jobs with " + ListController.columnChoices[searchType] + ": " + searchTerm;
            ViewBag.jobs = jobs;

            return View();
        }
    }
}
