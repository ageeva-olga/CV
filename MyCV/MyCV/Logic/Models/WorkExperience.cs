using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCV.Logic.Models
{
    public class WorkExperience
    {
        public int Begin { get; set; }

        public int End { get; set; }

        public string WorkName { get; set; }

        public string PositionName { get; set; }

        public Guid Id { get; set; }

        public List<Skill> Skills { get; set; }

        public WorkExperience()
        {
            Skills = new List<Skill>();
        }
    }
}