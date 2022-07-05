using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wizards.Core.Model;

namespace WizardsWeb.ModelViews
{
    public class PlayerDetailsModelView
    {
        public int Id { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string Password { get; set; }

        [Display(Name = "Email addres")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public List<Hero> Heroes = new();

        public PlayerDetailsModelView(Player player)
        {
            this.Id = player.Id;
            this.UserName = player.UserName;
            this.Password = player.Password;
            this.Email = player.Email;
            this.DateOfBirth = player.DateOfBirth;
            this.Heroes = player.Heroes;
        }
    }
}