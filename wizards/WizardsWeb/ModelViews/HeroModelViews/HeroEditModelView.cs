using System.ComponentModel.DataAnnotations;


namespace WizardsWeb.ModelViews;

public class HeroEditModelView
{
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