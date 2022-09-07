using System;
using System.Collections.Generic;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.WorldModels.ModelsDto.Properties;

namespace WizardsWeb.ModelViews.ExplorationModelViews;

public class HeroSection
{
    public string NickName { get; set; }
    public HeroProfession Profession { get; set; }
    public int AvatarImageNumber { get; set; }

    public List<CombatHeroSkillDto> HeroSkills { get; set; }

    public bool IsHeroStunned { get; set; }
    public int MaxHeroHealth { get; set; }
    public int CurrentHeroHealth { get; set; }

    public int GetCurrentHealthPercent()
    {
        return (int)Math.Round((CurrentHeroHealth / (double)MaxHeroHealth) * 100, 0);
    }
}