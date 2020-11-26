using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public enum PageViewMode
    {
        View = 1, 
        EditPersonalInfo = 2,
        EditEducation = 3,
        EditWorkExperience = 4,
        EditSkillCategory = 5,
        EditSkill = 6
    }
}