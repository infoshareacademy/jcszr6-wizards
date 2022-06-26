using System.ComponentModel.DataAnnotations;
using Wizards.BusinessLogic;

namespace WizardsWeb.ModelViews
{
    public class PasswordChangeModelView
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        [Required]
        [Display(Name ="Enter actual Password")]
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

        public PasswordChangeModelView() { }
        public PasswordChangeModelView(Player player)
        {
            Id = player.Id;
            UserName = player.UserName;
        }

        public Player ToPlayer()
        {
            return new Player() { Id= this.Id, Password = this.NewPassword};
        }
    }
}