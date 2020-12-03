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
                NewEducation = new EducationViewModel()
            },
            WorkExperienceBlock = new WorkExperienceListViewModel()
            {
                NewWorkExpirience = new WorkExperienceViewModel()
            },
            SkillCategoryBlock = new SkillsCategoryListViewModel()
            {
                NewSkillCategory = new SkillsCategoryViewModel(),
                SkillsCategoryList = new List<SkillsCategoryViewModel>()
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

            var expRepo = new WorkExperienceRepository();
            var experience = expRepo.GetWorkExperience();

            var skillsRepo = new SkillsRepository();
            var skills = skillsRepo.GetSkills();

            ViewBag.Mode = mode ?? PageViewMode.View;
            ModelState.Clear();
            Model.PersonalInfo = new PersonalInfoViewModel(personalInfo);

            Model.EducationBlock.EducationList = educations.Select(x => new EducationViewModel(x)).ToList();
            Model.EducationBlock.NewEducation = new EducationViewModel();

            Model.WorkExperienceBlock.WorkExperienceList = experience.Select(x => new WorkExperienceViewModel(x)).ToList();
            Model.WorkExperienceBlock.NewWorkExpirience = new WorkExperienceViewModel();

            Model.SkillCategoryBlock.SkillsCategoryList = skills.Select(x => new SkillsCategoryViewModel(x)).ToList();

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

            if (id != null)
            {
                var workExpRepo = new WorkExperienceRepository();
                workExpRepo.DeleteWorkExperience(id);
            }


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

        [HttpGet]
        public ActionResult DeleteSkillsCategory(Guid id)
        {
            var skillRepo = new SkillsRepository();
            skillRepo.DeleteSkillCategory(id);

            ViewBag.Mode = PageViewMode.EditSkillCategory;

            return RedirectToAction("/", new { mode = "EditSkillCategory" });
        }

        [HttpPost]
        public ActionResult AddSkillCategory(SkillsCategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = new SkillCategory();
                viewModel.FillModel(model);
                var skillCatRepo = new SkillsRepository();
                skillCatRepo.AddSkillCategory(model);
            }
            Model.SkillCategoryBlock.NewSkillCategory = viewModel;
            ViewBag.Mode = PageViewMode.EditSkillCategory;

            return View("Index", Model);
        }

        [HttpGet]
        public ActionResult DeleteSkill(Guid id)
        {
            var skillRepo = new SkillsRepository();
            skillRepo.DeleteSkill(id);

            ViewBag.Mode = PageViewMode.EditSkillCategory;

            return RedirectToAction("/", new { mode = "EditSkillCategory" });
        }

        public ActionResult AddSkill(SkillViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = new Skill();
                viewModel.FillModel(model);
                var skillRepo = new SkillsRepository();
                skillRepo.AddSkill(model, viewModel.SkillCategory);
            }
            //Model.SkillCategoryBlock.NewSkillCategory = viewModel;
            ViewBag.Mode = PageViewMode.EditSkillCategory;

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