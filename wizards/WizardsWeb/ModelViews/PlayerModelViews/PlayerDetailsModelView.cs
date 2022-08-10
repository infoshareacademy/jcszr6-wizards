using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wizards.Core.Model;

namespace WizardsWeb.ModelViews
{
    public class PlayerDetailsModelView
    {
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Email addres")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public List<Hero> Heroes = new();

        public PlayerDetailsModelView() { }
    }
}