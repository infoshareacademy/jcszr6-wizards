using System;
using System.Collections.Generic;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.WorldModels.ModelsDto.Properties;

namespace WizardsWeb.ModelViews.CombatModelViews;

public class HeroSectionModelView
{
    public string NickName { get; set; }
    public HeroProfession Profession { get; set; }
    public int AvatarImageNumber { get; set; }

    public List<HeroSkillModelView> Skills { get; set; }

    public bool IsStunned { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }

    public int GetCurrentHealthPercent()
    {
        return (int)Math.Round((CurrentHealth / (double)MaxHealth) * 100, 0);
    }
}