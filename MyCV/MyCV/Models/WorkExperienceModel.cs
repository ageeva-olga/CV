using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class WorkExperienceModel
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Ожидается число")]
        public string Begin { get; set; }

        [Required]
        public string End { get; set; }

        [Required]
        public string WorkName { get; set; }

        [Required(ErrorMessage ="*")]
        public string PositionName { get; set; }
        public Guid Id { get; set; }

        public WorkExperienceModel(string begin, string end, string workName, string positionName)
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