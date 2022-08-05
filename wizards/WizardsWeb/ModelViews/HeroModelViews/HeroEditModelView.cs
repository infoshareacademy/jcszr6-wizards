using System.ComponentModel.DataAnnotations;
using Wizards.Core.Model;
using Wizards.Core.Model.Enums;


namespace WizardsWeb.ModelViews;

public class HeroEditModelView
{
    public int Id { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(20)]
    [Display(Name = "Nick Name")]
    public string NickName { get; set; }

    [Required]
    public int AvatarImageNumber { get; set; }

    public int Cost { get; set; }
    public int Gold { get; set; }

    public HeroEditModelView() { }
}