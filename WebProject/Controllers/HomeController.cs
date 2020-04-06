using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {

        private NameService _assets = new NameService();

        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        

        public IActionResult Index(string criteria)
        {
              
            //update viewdata criteria
            switch (criteria)
            {
                case "Hanner":
                    ViewData["SearchCriteria"] = criteria;
                    break;
                case "Taever":
                    ViewData["SearchCriteria"] = "Tæver";
                    break;
                case "StoreHunde":
                    ViewData["SearchCriteria"] = "Store Hunde";
                    break;
                case "SmaeHunde":
                    ViewData["SearchCriteria"] = "Små Hunde";
                    break;
                case null:
                    ViewData["SearchCriteria"] = "Alle Navne";
                    break;
            }


            //get names
            List<string> names = new List<string>();
            if (criteria == "AlleNavne" || criteria == null)
                names = _assets.GetAllNames();
            else
                names = _assets.GetNamesWithCriteria(criteria);

            names.Sort();

            return View(names);
        }

      




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
