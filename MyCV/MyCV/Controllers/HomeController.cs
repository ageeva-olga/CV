using MyCV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCV.Controllers
{
    public class HomeController : Controller
    {
        public static PersonalInfoModel Model = new PersonalInfoModel("Olga", "Ageeva", "+79200513315", "olga.ageeva.999@mail.ru");
        public ActionResult Index()
        {
            return View(Model);
        }

        [HttpGet]
        public ActionResult EditPersonalInfo()
        { 
            return View(Model);
        }

        [HttpPost]
        public ActionResult EditPersonalInfo(PersonalInfoModel model)
        {
            Model = model;
            return RedirectToAction("/");
        }
    }
}