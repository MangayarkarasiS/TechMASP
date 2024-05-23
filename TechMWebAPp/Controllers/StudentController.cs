using Microsoft.AspNetCore.Mvc;
using TechMWebAPp.Models;

namespace TechMWebAPp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetStudentDetails(int Id)
        {
            StudentRepository repository = new StudentRepository();
            Book bookd=repository.GetBookById(Id);
            return Json(bookd);
           /* Student studentDetails = repository.GetStudentById(Id);
            return Json(studentDetails);*/
        }
    }
}
