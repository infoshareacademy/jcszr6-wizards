using System.ComponentModel.DataAnnotations;
using Wizards.Core.Model.Enums;

namespace WizardsWeb.ModelViews.HeroModelViews;

public class HeroCreateModelView
{
    [Required]
    [MinLength(3)]
    [MaxLength(20)]
    [Display(Name = "Nick Name")]
    public string NickName { get; set; }

    [Required]
    public HeroProfession Profession { get; set; }
    
    [Required]
    public int AvatarImageNumber { get; set; }
}