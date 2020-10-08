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
        //public static PersonalInfoModel Model = new PersonalInfoModel("Olga", "Ageeva", "+79200513315", "olga.ageeva.999@mail.ru");
        public static FrontPageModel Model = new FrontPageModel()
        {
            PersonalInfo = new PersonalInfoModel("Olga", "Ageeva", "+79200513315", "olga.ageeva.999@mail.ru"),
            EducationBlock = new EducationListModel()
            {
                EducationList = new List<EducationModel>()
                {
                    new EducationModel(new DateTime(2006, 1, 1), new DateTime(2015, 1, 1), "Общеобразовательная школа №103"),
                    new EducationModel(new DateTime(2015, 1, 1), new DateTime(2017, 1, 1), "НТЛ №38"),
                    new EducationModel(new DateTime(2017, 1, 1), new DateTime(2020, 1, 1), "ННГУ им. Лобачевского, Институт Информационных технологий, математики и механики, Факультет Математика и компьютерные науки")
                }
            }
        };
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
            Model.PersonalInfo = model;
            return RedirectToAction("/");
        }
    }
}