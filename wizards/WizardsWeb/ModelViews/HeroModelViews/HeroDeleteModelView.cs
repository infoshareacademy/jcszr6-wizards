using System;
using System.ComponentModel.DataAnnotations;
using Wizards.Core.Model;
using Wizards.Core.Model.Enums;

namespace WizardsWeb.ModelViews;

public class HeroDeleteModelView
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public string NickName { get; set; }
    public HeroProfession Profession { get; set; }
    public int AvatarImageNumber { get; set; }
    public int  Gold { get; set; }
    public Statistics Statistics { get; set; }
    
    [Required(ErrorMessage = "You have to enter Nick Name to confirm delete!")]
    [Display(Name = "Enter Nick Name to confirm")]
    public string ConfirmNickName { get; set; }

    public HeroDeleteModelView() { }
    public HeroDeleteModelView(Hero hero)
    {
        this.Id = hero.Id;
        this.NickName = hero.NickName;
        this.Profession = hero.Profession;
        this.AvatarImageNumber = hero.AvatarImageNumber;
        this.Gold = hero.Gold;
        this.Statistics = hero.Statistics;
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