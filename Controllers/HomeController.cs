using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDSolutionsApp.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult About()
        {
            ViewBag.Message = "This is an ASP.NET application developed for an application at SD Solutions. It was developed using .NET Framework 4.8, SQL Server, C# and Javascript, and Entity Framework.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "You can find my contact information here.";

            return View();
        }
    }
}