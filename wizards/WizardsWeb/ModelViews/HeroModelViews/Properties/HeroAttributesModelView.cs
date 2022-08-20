using System.ComponentModel.DataAnnotations;

namespace WizardsWeb.ModelViews.HeroModelViews.Properties;

public class HeroAttributesModelView
{
    public int Id { get; set; }

    [Display(Name = "Daily Reward Energy")]
    public int DailyRewardEnergy { get; set; }

    // Offensive
    public int Damage { get; set; }
    public int Precision { get; set; }
    public int Specialization { get; set; }

    // Defensive
    public int MaxHealth { get; set; }
    public int Reflex { get; set; }
    public int Defense { get; set; }

    public string GetAttributeValueColor(int value)
    {
        var color = "text-dark";

        if (value > 0)
        {
            color = "text-success";
        }
        else if (value < 0)
        {
            color = "text-danger";
        }

        return color;
    }
}