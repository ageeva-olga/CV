﻿using MyCV.Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class SkillsCategoryViewModel
    {
        [Required(ErrorMessage = "*")]
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
            Skills = model.Skills.Select(x => new SkillViewModel("DeleteSkill", x)).ToList();
        }

        public void FillModel(SkillCategory model)
        {
            model.Name = Name;
        }
    }
}