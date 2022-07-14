using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Wizards.Core.Model;
using Wizards.Core.Model.Enums;
using Wizards.Core.Model.ManyToManyTables;

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

    public Hero ToHero()
    {
        return new Hero()
        {
            NickName = this.NickName,
            AvatarImageNumber = this.AvatarImageNumber,
            Profession = this.Profession,
        };
    }
}