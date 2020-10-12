using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class FrontPageModel
    {
        public PersonalInfoModel PersonalInfo { get; set; }
        public EducationListModel EducationBlock { get; set; }
        public WorkExperienceListModel WorkExperienceBlock { get; set; }

        //public PageMode Mode { get; set; }
    }
}