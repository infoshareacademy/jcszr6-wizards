using Wizards.Core.Model;
using Wizards.Core.Model.Enums;
using WizardsWeb.ModelViews.Properties;

namespace WizardsWeb.ModelViews;

public class HeroDetailsModelView
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public string NickName { get; set; }
    public HeroProfession Profession { get; set; }
    public int AvatarImageNumber { get; set; }
    public int Gold { get; set; }
    public StatisticsModelView Statistics { get; set; }
    public HeroAttributesModelView Attributes { get; set; }

    public HeroDetailsModelView() { }
    public HeroDetailsModelView(Hero hero)
    {
        this.Id = hero.Id;
        this.NickName = hero.NickName;
        this.Profession = hero.Profession;
        this.AvatarImageNumber = hero.AvatarImageNumber;
        this.Gold = hero.Gold;
        this.Statistics = new StatisticsModelView(hero.Statistics);
        this.Attributes = new HeroAttributesModelView(hero.Attributes);
    }

    public string GetWinRatio()
    {
        float winRatio = 0f;

        if (Statistics.TotalMatchPlayed > 0)
        {
            winRatio = (float)((float)Statistics.TotalMatchWin / (float)Statistics.TotalMatchPlayed);
        }

        return $"{winRatio:0.000}";
    }

    public string AvatarImageAddres()
    {
        return $"Images/Hero/Avatars/Wizard-{AvatarImageNumber}.png";
    }
    public string ProfessionImageAddres()
    {
        return $"Images/Hero/Professions/{Profession.ToString()}.png";
    }
}