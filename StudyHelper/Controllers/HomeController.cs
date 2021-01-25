using System.Web.Mvc;
using StudyHelper.Models;

namespace StudyHelper.Controllers
{
    public class HomeController : Controller
    {
        private HomeWorkContext HomeWorkContext = new HomeWorkContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HomeWorks()
        {

            ViewBag.HomeWorks = HomeWorkContext.GetHomeWorks().Result;
            return View();
        }

        [HttpPost]
        public string Index(HomeWork homeWork)
        {
            homeWork.Id = (int) (HomeWorkContext.GetSize() + 1);
            HomeWorkContext.Add(homeWork);
            return ("Thank you");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}