using System.ComponentModel.DataAnnotations;
using Wizards.Core.Model;
using Wizards.Core.Model.Enums;


namespace WizardsWeb.ModelViews;

public class HeroCreateModelView
{
    public int PlayerId { get; set; }
    
    [Required]
    [MinLength(3)]
    [MaxLength(20)]
    [Display(Name = "Nick Name")]
    public string NickName { get; set; }

    [Required]
    public HeroProfession Profession { get; set; }
    
    [Required]
    public int AvatarImageNumber { get; set; }

    public HeroCreateModelView() { }
}