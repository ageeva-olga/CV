using MyCV.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class SkillViewModel
    {
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