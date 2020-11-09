using MyCV.DAL;
using MyCV.Logic.Models;
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
        public static FrontPageViewModel Model = new FrontPageViewModel()
        {
            EducationBlock = new EducationListViewModel()
            {
                EducationList = new List<EducationViewModel>()
                {
                    new EducationViewModel("2006", "2015", "Общеобразовательная школа №103"),
                    new EducationViewModel("2015", "2017", "НТЛ №38"),
                    new EducationViewModel("2017", "2020", "ННГУ им. Лобачевского, Институт Информационных технологий, математики и механики, Факультет Математика и компьютерные науки")
                },
                NewEducation = new EducationViewModel()
            },
            WorkExperienceBlock = new WorkExperienceListViewModel()
            {

                WorkExperienceList = new List<WorkExperienceViewModel>()
               {
                   new WorkExperienceViewModel("2010", "2011", "BastHouse","Продавец котят"),
                   new WorkExperienceViewModel("2020", "2020", "СШОР по СП и КС","Тренер-берейтор")
               },
                NewWorkExpirience = new WorkExperienceViewModel()
            }
        };

        public HomeController()
        {
            ViewBag.Mode = PageViewMode.View;
        }


        [HttpGet]
        public ActionResult Index(PageViewMode? mode)
        {
            var repo = new ProfileInfoRepository();
            var personalInfo = repo.GetPersonalInfo();

            ViewBag.Mode = mode ?? PageViewMode.View;
            ModelState.Clear();
            Model.PersonalInfo = new PersonalInfoViewModel(personalInfo);
            Model.WorkExperienceBlock.NewWorkExpirience = new WorkExperienceViewModel();
            Model.EducationBlock.NewEducation = new EducationViewModel();
            return View("Index", Model);
        }

        [HttpGet]
        public ActionResult DeleteEducation(Guid id)
        {
            var removedElement = Model.EducationBlock.EducationList.First(item => item.Id == id);
            Model.EducationBlock.EducationList.Remove(removedElement);

            ViewBag.Mode = PageViewMode.EditEducation;

            return RedirectToAction("/", new { mode = "EditEducation" });
        }

        [HttpPost]
        public ActionResult AddEducation(EducationViewModel model)
        {
            if (ModelState.IsValid)
            {
                Model.EducationBlock.EducationList.Add(model);
            }
            Model.EducationBlock.NewEducation = model;

            ViewBag.Mode = PageViewMode.EditEducation;

            return View("Index", Model);
        }

        [HttpGet]
        public ActionResult DeleteWorkExperience(Guid id)
        {
            var removeElement = Model.WorkExperienceBlock.WorkExperienceList.First(item => item.Id == id);
            Model.WorkExperienceBlock.WorkExperienceList.Remove(removeElement);

            ViewBag.Mode = PageViewMode.EditWorkExperience;

            return RedirectToAction("/", new { mode = "EditWorkExperience" });
        }

        [HttpPost]
        public ActionResult AddWorkExperience(WorkExperienceViewModel model)
        {
            if (ModelState.IsValid)
            {
                Model.WorkExperienceBlock.WorkExperienceList.Add(model);
            }
            Model.WorkExperienceBlock.NewWorkExpirience = model;
            ViewBag.Mode = PageViewMode.EditWorkExperience;

            return View("Index", Model);
        }

        [HttpPost]
        public ActionResult EditPersonalInfo(PersonalInfoViewModel viewModel)
        {
            var repo = new ProfileInfoRepository();
            var personalInfo = repo.GetPersonalInfo();

            viewModel.FillModel(personalInfo);
            repo.SavePersonalInfo(personalInfo);

            Model.PersonalInfo = viewModel;
            return RedirectToAction("/");
        }
    }
}