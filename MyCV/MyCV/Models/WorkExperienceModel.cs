using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class WorkExperienceModel
    {
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public string WorkName { get; set; }
        public string PositionName { get; set; }
        public Guid Id { get; set; }

        public WorkExperienceModel(DateTime begin, DateTime end, string workName, string positionName)
            : this()
        {
            Begin = begin;
            End = end;
            WorkName = workName;
            PositionName = positionName;
        }

        public WorkExperienceModel()
        {
            Id = Guid.NewGuid();
        }
    }
}