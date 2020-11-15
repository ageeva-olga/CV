using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class ProfessionalSkillsViewModel
    {
        List<string> NameSkill { get; set; }
        List<string> Names { get; set; }

        public ProfessionalSkillsViewModel()
        {
        }

        public ProfessionalSkillsViewModel(string nameSkill, string names)
        {
            NameSkill.Add(nameSkill);
            Names.Add(names);
        }
    }
}