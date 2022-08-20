using System.ComponentModel.DataAnnotations;

namespace WizardsWeb.ModelViews.PlayerModelViews;

public class PlayerLogInModelView
{
    [Required]
    [Display(Name = "User Name")]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}