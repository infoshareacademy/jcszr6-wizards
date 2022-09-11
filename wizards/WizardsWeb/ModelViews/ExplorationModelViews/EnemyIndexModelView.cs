using System.ComponentModel.DataAnnotations;
using Wizards.Core.Model.WorldModels.Enums;

namespace WizardsWeb.ModelViews.ExplorationModelViews;

public class EnemyIndexModelView
{
    public int Id { get; set; }
    public string Name { get; set; }
    public EnemyType Type { get; set; }
    public string Description { get; set; }
    public int Tier { get; set; }
    public int AvatarImageNumber { get; set; }
    
    [Display(Name = "Location: ")]
    public string EnemyStageName { get; set; }
}