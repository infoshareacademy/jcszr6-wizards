using System;
using System.ComponentModel.DataAnnotations;
using Wizards.Core.Model;

namespace WizardsWeb.ModelViews;

public class HeroDeleteModelView
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public string NickName { get; set; }
    [Required]
    public string ConfirmNickName { get; set; }

    public Statistics Statistics { get; set; }

    public HeroDeleteModelView() { }
    public HeroDeleteModelView(Hero hero)
    {
        this.Id = hero.Id;
        this.NickName = hero.NickName;
        this.Statistics = hero.Statistics;
    }

    public string WinRatio()
    {
        float result;
        
        if (Statistics.TotalMatchPlayed == 0)
            result = 0;
        else
            result = (float)Statistics.TotalMatchWin / (float)Statistics.TotalMatchPlayed;
        
        return $"({result:##,000}";
    }
}