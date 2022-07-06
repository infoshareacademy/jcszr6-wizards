using System;
using System.ComponentModel.DataAnnotations;
using Wizards.Core.Model;

namespace WizardsWeb.ModelViews
{
    public class PlayerDeleteModelView
    {
        public int Id { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Confirm deleting Player's Account with Password")]
        [DataType(DataType.Password)]
        public string PasswordToConfirmDelete { get; set; }

        [Display(Name = "Email addres")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public int HeroesCount = new();

        public PlayerDeleteModelView() { }
        public PlayerDeleteModelView(Player player)
        {
            Id = player.Id;
            UserName = player.UserName;
            Email = player.Email;
            DateOfBirth = player.DateOfBirth;
            HeroesCount = player.Heroes.Count;
        }

    }
}