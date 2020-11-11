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
                //EducationList = new List<EducationViewModel>()
                //{
                //    new EducationViewModel("2006", "2015", "Общеобразовательная школа №103"),
                //    new EducationViewModel("2015", "2017", "НТЛ №38"),
                //    new EducationViewModel("2017", "2020", "ННГУ им. Лобачевского, Институт Информационных технологий, математики и механики, Факультет Математика и компьютерные науки")
                //},
                NewEducation = new EducationViewModel()
            },
            WorkExperienceBlock = new WorkExperienceListViewModel()
            {

               //WorkExperienceList = new List<WorkExperienceViewModel>()
               //{
               //    new WorkExperienceViewModel("2010", "2011", "BastHouse","Продавец котят"),
               //    new WorkExperienceViewModel("2020", "2020", "СШОР по СП и КС","Тренер-берейтор")
              // },
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
            var repo = new PersonalInfoRepository();
            var personalInfo = repo.GetPersonalInfo();

            var eduRepo = new EducationRepository();
            var educations = eduRepo.GetEducations();

            ViewBag.Mode = mode ?? PageViewMode.View;
            ModelState.Clear();
            Model.PersonalInfo = new PersonalInfoViewModel(personalInfo);

            Model.EducationBlock.EducationList = educations.Select(x => new EducationViewModel(x)).ToList();
            Model.EducationBlock.NewEducation = new EducationViewModel();
            Model.WorkExperienceBlock.NewWorkExpirience = new WorkExperienceViewModel();

            return View("Index", Model);
        }

        [HttpGet]
        public ActionResult DeleteEducation(Guid id)
        {
            var eduRepo = new EducationRepository();
            eduRepo.DeleteEducation(id);

            ViewBag.Mode = PageViewMode.EditEducation;

            return RedirectToAction("/", new { mode = "EditEducation" });
        }

        [HttpPost]
        public ActionResult AddEducation(EducationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = new Education();
                viewModel.FillModel(model);
                var eduRepo = new EducationRepository();
                eduRepo.AddEducation(model);
            }
            Model.EducationBlock.NewEducation = viewModel;

            ViewBag.Mode = PageViewMode.EditEducation;

            return View("Index", Model);
        }

        [HttpGet]
        public ActionResult DeleteWorkExperience(Guid id)
        {
            var workExpRepo = new WorkExperienceRepository();
            workExpRepo.DeleteWorkExperience(id);

            ViewBag.Mode = PageViewMode.EditWorkExperience;

            return RedirectToAction("/", new { mode = "EditWorkExperience" });
        }

        [HttpPost]
        public ActionResult AddWorkExperience(WorkExperienceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = new WorkExperience();
                viewModel.FillModel(model);
                var workExpRepo = new WorkExperienceRepository();
                workExpRepo.AddWorkExperience(model);
            }
            Model.WorkExperienceBlock.NewWorkExpirience = viewModel;
            ViewBag.Mode = PageViewMode.EditWorkExperience;
            
            return View("Index", Model);
        }

        [HttpPost]
        public ActionResult EditPersonalInfo(PersonalInfoViewModel viewModel)
        {
            var repo = new PersonalInfoRepository();
            var personalInfo = repo.GetPersonalInfo();

            viewModel.FillModel(personalInfo);
            repo.SavePersonalInfo(personalInfo);

            Model.PersonalInfo = viewModel;
            return RedirectToAction("/");
        }
    }
}