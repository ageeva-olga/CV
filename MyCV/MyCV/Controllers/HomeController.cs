using MyCV.DAL;
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
        public static FrontPageModel Model = new FrontPageModel()
        {
            PersonalInfo = new PersonalInfoModel("Olga", "Ageeva", "+79200513315", "olga.ageeva.999@mail.ru"),
            EducationBlock = new EducationListModel()
            {
                EducationList = new List<EducationModel>()
                {
                    new EducationModel("2006", "2015", "Общеобразовательная школа №103"),
                    new EducationModel("2015", "2017", "НТЛ №38"),
                    new EducationModel("2017", "2020", "ННГУ им. Лобачевского, Институт Информационных технологий, математики и механики, Факультет Математика и компьютерные науки")
                },
                NewEducation = new EducationModel()
            },
            WorkExperienceBlock = new WorkExperienceListModel()
            {

                WorkExperienceList = new List<WorkExperienceModel>()
               {
                   new WorkExperienceModel("2010", "2011", "BastHouse","Продавец котят"),
                   new WorkExperienceModel("2020", "2020", "СШОР по СП и КС","Тренер-берейтор")
               },
                NewWorkExpirience = new WorkExperienceModel()
            }
        };

        public HomeController()
        {
            ViewBag.Mode = PageMode.View;
        }


        [HttpGet]
        public ActionResult Index(PageMode? mode)
        {
            //var repo = new ProfileInfoRepository();
            //repo.GetProfileInfo();

            ViewBag.Mode = mode ?? PageMode.View;
            ModelState.Clear();
            Model.WorkExperienceBlock.NewWorkExpirience = new WorkExperienceModel();
            Model.EducationBlock.NewEducation = new EducationModel();
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
            if (ModelState.IsValid)
            {
                Model.EducationBlock.EducationList.Add(model);
            }
            Model.EducationBlock.NewEducation = model;

            ViewBag.Mode = PageMode.EditEducation;

            return View("Index", Model);
        }

        [HttpGet]
        public ActionResult DeleteWorkExperience(Guid id)
        {
            var removeElement = Model.WorkExperienceBlock.WorkExperienceList.First(item => item.Id == id);
            Model.WorkExperienceBlock.WorkExperienceList.Remove(removeElement);

            ViewBag.Mode = PageMode.EditWorkExperience;

            return RedirectToAction("/", new { mode = "EditWorkExperience" });
        }

        [HttpPost]
        public ActionResult AddWorkExperience(WorkExperienceModel model)
        {
            if (ModelState.IsValid)
            {
                Model.WorkExperienceBlock.WorkExperienceList.Add(model);
            }
            Model.WorkExperienceBlock.NewWorkExpirience = model;
            ViewBag.Mode = PageMode.EditWorkExperience;

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