using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Data.SqlClient;
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

        SqlConnection con = new SqlConnection("server=(localdb)\\MSSQLLocalDB;Integrated security=true;initial catalog=LibraryDB");
        public IActionResult Index()
        {
            string[] countries = { "India", "China", "korea", "Japan", "Indonesia" };
            ViewBag.country=countries;
            return View();
        }

        
        public ActionResult LoginPage()
        {
            return View();
        }
        public ActionResult Log()
        {
            string nUserName = Request.Form["UserName"];
            string nPassword = Request.Form["Password"];
            con.Open();
            SqlCommand cmd = new SqlCommand("select username,password from login", con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string unm = dr[0].ToString();
                string pwd = dr[1].ToString();

                if (nUserName == unm && nPassword == pwd)
                {
                    ViewBag.message = "login success";
                    break;
                }
                else
                    ViewBag.message = "login fails";
            }




/*            string id1 = Request.Form["UserName"].ToString();
            int id2 = int.Parse(id1);
            con.Open();
            SqlCommand cmd = new SqlCommand("select BookId,booknm from book where BookId=@id", con);
            cmd.Parameters.AddWithValue("@id", id2);

            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            
                string id= Convert.ToString(rdr["BookId"]);
                string nm =Convert.ToString( rdr["booknm"]);
            
            
            string nUserName = Request.Form["UserName"];
            string nPassword = Request.Form["Password"];
            if (string.Compare(id, nUserName) == 0 && string.Compare(nm, nPassword) == 0)

                ViewBag.message = "login success";
            else
                ViewBag.message = "login fail";

            // string sUsername = "Admin";
            //string sPassword = "Admin";
            /* if (string.Compare(sUsername, nUserName) == 0 && string.Compare(sPassword, nPassword) == 0)

                 ViewBag.message = "login success";
                else
                 ViewBag.message = "login fail";*/
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