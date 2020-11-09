using MyCV.Logic.Models;
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

        public EducationViewModel()
        {
        }

        public EducationViewModel(string begin, string end, string schoolName)
        {
            Begin = begin;
            End = end;
            SchoolName = schoolName;
            Id = Guid.NewGuid();
        }

        public EducationViewModel(Education education)
        {
            Id = education.Id;
            Begin = education.Begin.ToString();
            End = education.End.ToString();
            SchoolName = education.SchoolName;
        }

        public void FillModel(Education model)
        {
            model.SchoolName = SchoolName;
            model.Begin = int.Parse(Begin);
            model.End = int.Parse(End);
        }

    }
}