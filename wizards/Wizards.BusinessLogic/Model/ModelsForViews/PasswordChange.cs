using System.ComponentModel.DataAnnotations;

namespace Wizards.BusinessLogic
{
    public class PasswordChange
    {
        public Player Player { get; set; }
        public string OldPassword { get; set; }

        [Required]
        [Display(Name ="Enter actual Password")]
        [Compare("OldPassword", ErrorMessage = "Incorrect actual Password!")]
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

        public PasswordChange(Player player)
        {
            Player = player;
        }

        public Player GetPlayerWithNewPassword()
        {
            return new Player()
            {
                Id = Player.Id,
                Password = this.NewPassword,
                Email= Player.Email,
                DateOfBirth= Player.DateOfBirth,
            };
        }
    }
}