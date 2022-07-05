using System;
using System.ComponentModel.DataAnnotations;
using Wizards.Core.Model;

namespace WizardsWeb.ModelViews
{
    public class PlayerEditModelView
    {
        public int Id { get; set; }

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

        public PlayerEditModelView(Player player)
        {
            this.Id = player.Id;
            this.UserName = player.UserName;
            this.Email = player.Email;
            this.DateOfBirth = player.DateOfBirth;
        }

        public Player ToPlayer()
        {
            return new Player()
            {
                Id = this.Id,
                Email = this.Email,
                DateOfBirth = this.DateOfBirth,
            };
        }
    }
}