using System.ComponentModel.DataAnnotations;

namespace WizardsWeb.ModelViews.ItemModelViews.Properties;

public class ItemAttributesDetailsModelView
{
    // Offensive
    public int Damage { get; set; }
    public int Precision { get; set; }
    public int Specialization { get; set; }

    // Defensive
    [Display(Name = "Maximum Health")]
    public int MaxHealth { get; set; }
    public int Reflex { get; set; }
    public int Defense { get; set; }

    public string AttributeValueToString(int value)
    {
        if (value > 0)
        {
            return $"+ {value}";
        }

        if (value < 0)
        {
            return $"- {value * -1}";
        }

        return $"  {value}";
    }

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