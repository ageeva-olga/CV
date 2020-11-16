using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class SkillsCategoryListViewModel
    {
        public List<SkillsCategoryViewModel> SkillsCategoryList { get; set; }
        public SkillsCategoryViewModel NewSkillCategory { get; set; }
    }
}