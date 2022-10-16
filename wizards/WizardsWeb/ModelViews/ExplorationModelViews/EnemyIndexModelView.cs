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
    public bool TrainingEnemy { get; set; }
    
    
    [Display(Name = "Location: ")]
    public string EnemyStageName { get; set; }

    [Display(Name = "Gold: ")]
    public int GoldReward { get; set; }

    [Display(Name = "Rank Points: ")]
    public int RankPointsReward { get; set; }

    public bool CanPlayerConquer { get; set; }
    public bool CanClaimReward { get; set; }
}