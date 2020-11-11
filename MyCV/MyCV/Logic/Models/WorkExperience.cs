using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCV.Logic.Models
{
    public class WorkExperience
    {
        public string Begin { get; set; }

        public string End { get; set; }

        public string WorkName { get; set; }

        public string PositionName { get; set; }

        public Guid Id { get; set; }
    }
}