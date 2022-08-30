namespace Wizards.Core.ConstParameters;

public static class Params
{
    public const double ItemFullyRepairedMax = 100.00d;
    public const double ItemFullyRepairedMin = 99.00d;
    
    public const double ItemInGoodConditionMin = 66.00d;
    public const double ItemDamagedMin = 33.00d;
    public const double ItemCrashedMin = 0.00d;
    
    public const double ItemInGoodConditionAttrFactor = 1.00d;
    public const double ItemDamagedAttrFactor = 0.75d;
    public const double ItemCrashedAttrFactor = 0.50d;
    

    public const double MaxDamageFactor = 1.10d;
    public const double MinDamageFactor = 0d;

    public const double MaxPercentNumber = 100d;
    public const double PercentDivider = 100d;

    public const int MinOutgoingDamage = 0;
    public const double BonusDamageFactor = 2d;

    public const double MaxHealingFactor = 1.25;
    public const double MinHealingFactor = 0.9;

    public const double SpecializationFactorForHealing = 2d;

    public const int MinOutgoingHealing = 0;
    public const double BonusHealingFactor = 1.5;
}