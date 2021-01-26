using System;
using System.IO;
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
                    homeWork.Id = (int) (HomeWorkContext.GetSize() + 1);
                    homeWork.UploadedFileName =
                        homeWork.Id.ToString() + Path.GetExtension(homeWork.PostedFile.FileName);

                    string path = Server.MapPath("~/Uploads/");
                    homeWork.PostedFile.SaveAs(path + homeWork.UploadedFileName);
                    ViewBag.Message = "File uploaded successfully";

                    HomeWorkContext.Add(homeWork);
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