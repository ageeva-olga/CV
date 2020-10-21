using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class EducationModel
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Ожидается число")]
        public string Begin { get; set; }

        [Required]
        public string End { get; set; }

        [Required]
        public string SchoolName { get; set; }

        [Required]
        public Guid Id { get; set; }

        public EducationModel(string begin, string end, string schoolName)
            :this()
        {
            Begin = begin;
            End = end;
            SchoolName = schoolName;
        }

        public EducationModel()
        {
            Id = Guid.NewGuid();
        }
    }
}