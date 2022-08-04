using System;
using System.ComponentModel.DataAnnotations;
using Wizards.Core.Model;

namespace WizardsWeb.ModelViews
{
    public class PlayerDeleteModelView
    {
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Confirm deleting Player's Account with Password")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        [Display(Name = "Email addres")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public int HeroesCount = new();

        public PlayerDeleteModelView() { }
    }
}