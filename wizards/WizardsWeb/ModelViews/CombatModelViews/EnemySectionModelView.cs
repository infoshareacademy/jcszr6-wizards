using System;
using Wizards.Core.Model.WorldModels.Enums;

namespace WizardsWeb.ModelViews.CombatModelViews;

public class EnemySectionModelView
{
    public string Name { get; set; }
    public EnemyType Type { get; set; }
    public int AvatarImageNumber { get; set; }

    public EnemySkillType SelectedSkillType { get; set; }
    public bool SelectedSkillStunning { get; set; }

    public bool IsStunned { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public int GoldReward { get; set; }

    public int GetCurrentHealthPercent()
    {
        return (int)Math.Round((CurrentHealth / (double)MaxHealth) * 100, 0);
    }
}