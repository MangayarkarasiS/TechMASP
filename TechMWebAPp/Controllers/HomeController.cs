using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechMWebAPp.Models;

namespace TechMWebAPp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string[] countries = { "India", "China", "korea", "Japan", "Indonesia" };
            ViewBag.country=countries;
            return View();
        }
        public IActionResult shift()
        {
            int num = 5;
            int sq = 5 * 5;
            ViewBag.valu = sq;
            return View();
        }
        public IActionResult callme()
        {
            return  View("Privacy");
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