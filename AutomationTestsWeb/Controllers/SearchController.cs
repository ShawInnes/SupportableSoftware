using System.Collections.Generic;
using System.Web.Mvc;

namespace AutomationTestsWeb.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string searchString)
        {
            List<string> results = new List<string>();

            results.Add(searchString);

            return View(results);
        }
    }
}