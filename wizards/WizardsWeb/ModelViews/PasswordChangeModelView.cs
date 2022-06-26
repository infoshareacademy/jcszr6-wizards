using System.ComponentModel.DataAnnotations;
using Wizards.BusinessLogic;

namespace WizardsWeb.ModelViews
{
    public class PasswordChangeModelView
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        [Required]
        [Display(Name ="Enter actual Password")]
        [Compare("Password", ErrorMessage = "Incorrect actual Password!")]
        [DataType(DataType.Password)]
        public string EnterOldPassword { get; set; }

        [Required]
        [Display(Name = "Enter new Password")]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [Display(Name = "Confirm new Password")]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "New Password and Confirm new Password should be the same!")]
        public string ConfirmPassword { get; set; }

        public PasswordChangeModelView(Player player)
        {
            Id = player.Id;
            UserName = player.UserName;
            Password = player.Password;
        }

        public PasswordChangeModelView()
        {
            
        }

        public Player GetPlayerWithNewPassword()
        {
            return new Player() { Id= this.Id, Password = this.NewPassword, UserName = this.UserName};
        }
    }
}