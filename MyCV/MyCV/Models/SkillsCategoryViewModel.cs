using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class SkillsCategoryViewModel
    {
        public string Name { get; set; }
        public List<SkillViewModel> Skills { get; set; }
        public Guid Id { get; set; }

        public SkillsCategoryViewModel()
        {
        }
    }
}