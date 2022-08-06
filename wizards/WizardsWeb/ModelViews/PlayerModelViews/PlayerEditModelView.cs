using System;
using System.ComponentModel.DataAnnotations;

namespace WizardsWeb.ModelViews
{
    public class PlayerEditModelView
    {
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email addres")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public PlayerEditModelView() { }
    }
}