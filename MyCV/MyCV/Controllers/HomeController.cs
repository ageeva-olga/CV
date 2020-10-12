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
            //Mode = PageMode.View,
            PersonalInfo = new PersonalInfoModel("Olga", "Ageeva", "+79200513315", "olga.ageeva.999@mail.ru"),
            EducationBlock = new EducationListModel()
            {
                EducationList = new List<EducationModel>()
                {
                    new EducationModel(new DateTime(2006, 1, 1), new DateTime(2015, 1, 1), "Общеобразовательная школа №103"),
                    new EducationModel(new DateTime(2015, 1, 1), new DateTime(2017, 1, 1), "НТЛ №38"),
                    new EducationModel(new DateTime(2017, 1, 1), new DateTime(2021, 1, 1), "ННГУ им. Лобачевского, Институт Информационных технологий, математики и механики, Факультет Математика и компьютерные науки")
                }
            },
            WorkExperienceBlock = new WorkExperienceListModel()
            {

                WorkExperienceList = new List<WorkExperienceModel>()
               {
                   new WorkExperienceModel(new DateTime(2010, 1, 1), new DateTime(2011, 1, 1), "BastHouse","Продавец котят"),
                   new WorkExperienceModel(new DateTime(2020, 03, 20), new DateTime(2020, 03, 28), "СШОР по СП и КС","Тренер-берейтор")
               }
            }
        };

        public HomeController()
        {
            ViewBag.Mode = PageMode.View;
        }


        [HttpGet]
        public ActionResult Index(string mode)
        {

            ViewBag.Mode = string.IsNullOrEmpty(mode) ? PageMode.View : PageMode.Edit;

            return View("Index", Model);
        }

        [HttpPost]
        public ActionResult EditPersonalInfo(PersonalInfoModel model)
        {
            Model.PersonalInfo = model;
            return RedirectToAction("/");
        }
    }
}