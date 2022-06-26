using System;
using System.ComponentModel.DataAnnotations;
using Wizards.BusinessLogic;

namespace WizardsWeb.ModelViews
{
    public class PlayerDeleteModelView
    {
        public int Id { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string Password { get; set; }
        
        [Required]
        [Display(Name = "Confirm deleting Player's Account with Password")]
        [Compare("Password", ErrorMessage = "Invalid Password!")]
        [DataType(DataType.Password)]
        public string PasswordToConfirmDelete { get; set; }

        [Display(Name = "Email addres")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public int HeroesCount = new();

        public PlayerDeleteModelView(Player player)
        {
            Id = player.Id;
            UserName = player.UserName;
            Password = player.Password;
            Email = player.Email;
            DateOfBirth = player.DateOfBirth;
            HeroesCount = player.Heroes.Count;
        }

        public PlayerDeleteModelView()
        {
            
        }
    }
}