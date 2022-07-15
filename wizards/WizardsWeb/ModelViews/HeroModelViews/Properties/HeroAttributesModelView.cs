﻿using System.ComponentModel.DataAnnotations;

namespace WizardsWeb.ModelViews.Properties;

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
    public int Health { get; set; }
    public int Reflex { get; set; }
    public int Defense { get; set; }
}