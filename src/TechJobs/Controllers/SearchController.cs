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
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Dictionary<String, String>> jobs;
            if (searchTerm != null)
            {
                if (searchType.Equals("all"))
                {
                    jobs = JobData.FindByValue(searchTerm);
                } else
                {
                    jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                }
            } else
            {
                return Redirect("/Search");
            }
            ViewBag.title = "Jobs with " + ListController.columnChoices[searchType] + ": " + searchTerm;
            ViewBag.jobs = jobs;

            return View();
        }
    }
}
