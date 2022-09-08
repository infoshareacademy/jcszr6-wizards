using System;
using Wizards.Core.Model.WorldModels.Enums;

namespace WizardsWeb.ModelViews.CombatModelViews;

public class EnemySectionModelView
{
    public string Name { get; set; }
    public EnemyType Type { get; set; }
    public int AvatarImageNumber { get; set; }

    public EnemySkillType EnemySelectedSkillType { get; set; }
    public bool EnemySelectedSkillStunning { get; set; }

    public bool IsEnemyStunned { get; set; }
    public int MaxEnemyHealth { get; set; }
    public int CurrentEnemyHealth { get; set; }

    public int GetCurrentHealthPercent()
    {
        return (int)Math.Round((CurrentEnemyHealth / (double)MaxEnemyHealth) * 100, 0);
    }
}