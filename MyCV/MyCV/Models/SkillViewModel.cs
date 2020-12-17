using MyCV.Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class SkillViewModel
    {
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }

        public Guid Id { get; set; }
        public Guid SkillCategory { get; set; }
        public string DeleteCommand { get; set; }

        public SkillViewModel() { }

        public SkillViewModel(string deleteCommand, Skill model)
        {
            Name = model.Name;
            Id = model.Id;
            DeleteCommand = deleteCommand;
        }

        public void FillModel(Skill model)
        {
            model.Name = Name;
        }
    }
}