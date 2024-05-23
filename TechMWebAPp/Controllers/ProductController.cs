using Microsoft.AspNetCore.Mvc;

namespace TechMWebAPp.Controllers
{
    public class ProductController : Controller
    {
        public ProductController() { }

        public IActionResult AddProd()
        {
            return View();
        }

        public IActionResult DeleteProd()
        {
            return View();
        }
    }
}
