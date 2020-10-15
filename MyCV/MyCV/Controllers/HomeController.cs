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
                    new EducationModel("2006", "2015", "Общеобразовательная школа №103"),
                    new EducationModel("2015", "2017", "НТЛ №38"),
                    new EducationModel("2017", "2020", "ННГУ им. Лобачевского, Институт Информационных технологий, математики и механики, Факультет Математика и компьютерные науки")
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
        public ActionResult Index(PageMode? mode)
        {

            ViewBag.Mode = mode ?? PageMode.View;

            return View("Index", Model);
        }

        [HttpGet]
        public ActionResult DeleteEducation(Guid id)
        {
            var removedElement = Model.EducationBlock.EducationList.First(item => item.Id == id);
            Model.EducationBlock.EducationList.Remove(removedElement);

            ViewBag.Mode = PageMode.EditEducation;

            return RedirectToAction("/", new { mode = "EditEducation" });
        }

        [HttpPost]
        public ActionResult AddEducation(EducationModel model)
        {
            Model.EducationBlock.EducationList.Add(model);

            ViewBag.Mode = PageMode.EditEducation;

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