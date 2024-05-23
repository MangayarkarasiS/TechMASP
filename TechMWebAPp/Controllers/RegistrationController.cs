
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Web;

namespace TechMWebAPp.Controllers
{
    public class RegistrationController : Controller
    {
       /* public ActionResult Index()
        {
            return View();
        }*/

        //returns viewresult
        public ViewResult VIndex()
        {
            ViewBag.ItemList = "Computer Shop Item List Page";
            ViewData["color"] = "Green";
            TempData["month"] = "Jan";
            return View();
        }

        //returns empty result
        public EmptyResult EIndex()
        {
            ViewBag.ItemList = "Hello Batch!";
            return new EmptyResult();
        }
        //redirects to another action method
        public RedirectResult AIndex()
        {
            return Redirect("VIndex");
        }
        //redirects to another url
        public RedirectResult UIndex()
        {
            return Redirect("https://www.w3schools.com");
        }
        //RedirectToRouteResult is used whenever we need to go 
        //from one action to another.It is responsible for the 
        //redirection to the actions within the application.
        public RedirectToRouteResult RRIndex()
        {
            return RedirectToRoute(new { controller = "Test", action = "Index" });
        }
        //The RedirectToAction Result is returning the result to a 
        //specified controller and action method.
        //if you are in the same controller and don’t want to give the name 
        //of controller then the better option of is, RedirectToAction 
        //helper method

        //public IActionResult RRRIndex()
        //{
        //    return RedirectToAction("https://www.w3schools.com");
        //    //return RedirectToAction("SecondIndex");
        //}
        public ActionResult SecondIndex()
        {
            return View();
        }
       /* public ActionResult RAIndex()
        {
            
           // return RedirectToAction("Index", "Home");
        }*/
        //returns JsonResult
        public JsonResult JIndex()
        {
            Employee emp = new Employee()
             {
                Id = "Emp1001",
                Name = "Jain",
                Mobile = "825415426"
            };
            return Json(emp);
            // return Json(new { Name = "Mangai", ID = 1 }, JsonRequestBehavior.AllowGet); 
        }

         
        public string sIndex(string id)
        {
            return "ID =" + id;
        }
        public ContentResult Content()
        {

            bool answer = DateTime.Now.Day + 2 == 25;
            if (answer)
            {
                return Content(" <script> alert('Correct') </script> ");
            }
            else
            {
                return Content("Not Correct"); ;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public FileResult Fileres()
        {
            return File("~/TextFile1.txt", "text/plain");
        }
       
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult LoginPage()
        {
            return View();
        }
        SqlConnection con = new SqlConnection("server=(localdb)\\MSSQLLocalDB;integrated security=true;initial catalog=LibraryDB; ");
        
        public IActionResult Log()
        {
           
            string nUserName = Request.Form["UserName"];
            string nPassword = Request.Form["Password"];
            con.Open();
            SqlCommand cmd = new SqlCommand("select username,password from login",con);

            SqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                string unm= dr[0].ToString();
                string pwd = dr[1].ToString();

                if (nUserName == unm && nPassword == pwd)
                {
                    ViewBag.message = "login success";
                    break;
                }
                else
                    ViewBag.message = "login fails";
            }



            /*string nUserName = Request.Form["UserName"];
            string nPassword = Request.Form["Password"];
            string sUsername = "Admin";
            string sPassword = "Admin";
            if (string.Compare(sUsername, nUserName) == 0 && string.Compare(sPassword, nPassword) == 0)

                ViewBag.message = "login success";
            else
                ViewBag.message = "login fail";*/
            return View();
        }
    }
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
    }
}
