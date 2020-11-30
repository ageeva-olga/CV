using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class FrontPageViewModel
    {
        public PersonalInfoViewModel PersonalInfo { get; set; }
        public EducationListViewModel EducationBlock { get; set; }
        public WorkExperienceListViewModel WorkExperienceBlock { get; set; }
        public SkillsCategoryListViewModel SkillCategoryBlock { get; set; }
    }
}