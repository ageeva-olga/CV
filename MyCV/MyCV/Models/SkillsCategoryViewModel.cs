using MyCV.Logic.Models;
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

        public SkillsCategoryViewModel(SkillCategory model)
        {
            Name = model.Name;
            Id = model.Id;
            Skills = model.Skills.Select(x => new SkillViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                SkillCategory = model.Id
            }).ToList();
        }

        public void FillModel(SkillCategory model)
        {
            model.Name = Name;
        }
    }
}