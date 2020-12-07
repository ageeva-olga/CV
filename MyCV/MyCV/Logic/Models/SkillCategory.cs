using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCV.Logic.Models
{
    public class SkillCategory
    {
        public string Name { get; set; }
        public List<Skill> Skills { get; set; }
        public Guid Id { get; set; }

        public SkillCategory()
        {
            Skills = new List<Skill>();
        }
    }
}