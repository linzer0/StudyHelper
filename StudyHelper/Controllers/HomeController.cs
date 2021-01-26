using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using StudyHelper.Models;

namespace StudyHelper.Controllers
{
    public class HomeController : Controller
    {
        private HomeWorkContext HomeWorkContext = new HomeWorkContext();

        [HttpGet]
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
        public ActionResult Index(HomeWork homeWork)
        {
            if (homeWork.PostedFile != null && homeWork.PostedFile.ContentLength > 0)
                try
                {
                    var fileName = homeWork.SubjectName + "/" + homeWork.WorkName + "/" + homeWork.VariantNumber;
                    string path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    homeWork.PostedFile.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message;
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}