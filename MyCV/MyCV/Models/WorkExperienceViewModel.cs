using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class WorkExperienceViewModel
    {
        [Required(ErrorMessage = "*")]
        [Range(0, int.MaxValue, ErrorMessage = Consts.NumberRequired)]
        public string Begin { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(0, int.MaxValue, ErrorMessage = Consts.NumberRequired)]
        public string End { get; set; }

        [Required(ErrorMessage = "*")]
        public string WorkName { get; set; }

        [Required(ErrorMessage ="*")]
        public string PositionName { get; set; }
        public Guid Id { get; set; }

        public WorkExperienceViewModel(string begin, string end, string workName, string positionName)
            : this()
        {
            Begin = begin;
            End = end;
            WorkName = workName;
            PositionName = positionName;
        }

        public WorkExperienceViewModel()
        {
            Id = Guid.NewGuid();
        }
    }
}