using MyCV.DAL;
using MyCV.Logic.Constracts;
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
        IPersonalInfoRepository personalInfoRepository;
        public HomeController()
        {
            ViewBag.Mode = PageViewMode.View;
            personalInfoRepository = new PersonalInfoRepository();
        }

        [HttpGet]
        public ActionResult Index(PageViewMode? mode)
        {
            ModelState.Clear();
            var model = GetFrontPageViewModel(mode);
            return View("Index", model);
        }

        [HttpGet]
        public ActionResult DeleteEducation(Guid id)
        {
            var eduRepo = new EducationRepository();
            eduRepo.DeleteEducation(id);

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
            var frontPageViewModel = GetFrontPageViewModel(PageViewMode.EditEducation);
            frontPageViewModel.EducationBlock.NewEducation = viewModel;

            return View("Index", frontPageViewModel);
        }

        [HttpGet]
        public ActionResult DeleteWorkExperience(Guid id)
        {

            if (id != null)
            {
                var workExpRepo = new WorkExperienceRepository();
                workExpRepo.DeleteWorkExperience(id);
            }

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
            var frontPageViewModel = GetFrontPageViewModel(PageViewMode.EditWorkExperience);
            frontPageViewModel.WorkExperienceBlock.NewWorkExpirience = viewModel;

            return View("Index", frontPageViewModel);
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

            return RedirectToAction("/", new { mode = "EditSkillCategory" });
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

            return new RedirectResult(Url.Action("Index", new { mode = "EditSkillCategory" }) + "#profskills");
        }

        [HttpPost]
        public ActionResult EditPersonalInfo(PersonalInfoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var personalInfo = personalInfoRepository.GetPersonalInfo();

                viewModel.FillModel(personalInfo);
                personalInfoRepository.SavePersonalInfo(personalInfo);

                return RedirectToAction("/");
            }
            var model = GetFrontPageViewModel(PageViewMode.EditPersonalInfo);
            model.PersonalInfo = viewModel;
            return View("Index", model);

        }

        [HttpGet]
        public ActionResult DeleteSkillExperience(Guid id)
        {
            var workExpRepo = new WorkExperienceRepository();
            workExpRepo.DeleteSkillExperience(id);

            return RedirectToAction("/", new { mode = "EditWorkExperience" });
        }

        private FrontPageViewModel GetFrontPageViewModel(PageViewMode? mode)
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

            var frontPageViewModel = new FrontPageViewModel()
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
                }
            };

            frontPageViewModel.PersonalInfo = new PersonalInfoViewModel(personalInfo);

            frontPageViewModel.EducationBlock.EducationList = educations.Select(x => new EducationViewModel(x)).ToList();
            frontPageViewModel.EducationBlock.NewEducation = new EducationViewModel();

            frontPageViewModel.WorkExperienceBlock.WorkExperienceList = experience.Select(x => new WorkExperienceViewModel(x)).ToList();
            frontPageViewModel.WorkExperienceBlock.NewWorkExpirience = new WorkExperienceViewModel();

            frontPageViewModel.SkillCategoryBlock.SkillsCategoryList = skills.Select(x => new SkillsCategoryViewModel(x)).ToList();
            frontPageViewModel.SkillCategoryBlock.NewSkillCategory = new SkillsCategoryViewModel();

            return frontPageViewModel;
        }
    }
}