using MyCV.Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class PersonalInfoViewModel
    {
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "*")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "*")]
        public string Email { get; set; }

        public string FullName => $"{Name} {Surname}";

        public PersonalInfoViewModel()
        {
        }

        public PersonalInfoViewModel(PersonalInfo model)
        {
            Name = model.Name;
            Surname = model.Surname;
            Email = model.Email;
            Phone = model.Phone;
        }

        public void FillModel(PersonalInfo model)
        {
            model.Name = Name;
            model.Surname = Surname;
            model.Email = Email;
            model.Phone = Phone;
        }

        public PersonalInfoViewModel(string name, string surname, string phone, string email)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            Email = email;
        }
    }
}