using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class EducationViewModel
    {
        [Required(ErrorMessage = "*")]
        [Range(0, int.MaxValue, ErrorMessage = Consts.NumberRequired)]
        public string Begin { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(0, int.MaxValue, ErrorMessage = Consts.NumberRequired)]
        public string End { get; set; }

        [Required(ErrorMessage = "*")]
        public string SchoolName { get; set; }

        public Guid Id { get; set; }

        public EducationViewModel(string begin, string end, string schoolName)
            :this()
        {
            Begin = begin;
            End = end;
            SchoolName = schoolName;
        }

        public EducationViewModel()
        {
            Id = Guid.NewGuid();
        }
    }
}