using Wizards.Core.Model.UserModels.Enums;
using Wizards.Services.Validation.Elements;
using Wizards.Services.Validation.ValidationTasks;
using Wizards.Services.Validation.ValidationTasks.Interfaces;

namespace Wizards.Services.Validation.Settings;

public static class ValidationSettingsFactory
{
    public static PlayerValidationSettings GetPlayersValidationSettings()
    {
        return new PlayerValidationSettings()
        {
            UserNameTasks = new List<IStringValidationTask>()
            {
                new IsNotNull(),
                new StringMinLength(3),
                new StringMaxLength(20),
                new RestrictedWords(),
                new AllowedCharacters("abcdefghijklmnopqrstuvwxyz1234567890-_"),
            },
            AlredyInUseTask = new AlredyInUse(),
            PasswordTasks = new List<IStringValidationTask>()
            {
                new IsNotNull(),
                new StringMinLength(8),
                new AllowedCharacters("abcdefghijklmnopqrstuvwxyz1234567890,.;:?!'@#$%^&*()[]_+-=`~"),
                new IsPasswordHardEnough()
            },
            EmailTasks = new List<IStringValidationTask>()
            {
                new IsNotNull(),
                new StringMinLength(5),
                new IsEmail(),
            },
            DateOfBirthTasks = new List<IDateValidationTask>()
            {
                new DateIsNotNull(),
                new DateMin(new DateTime(1900, 1, 1)),
                new RestrictedAge(10)
            }
        };
    }

    public static HeroValidationSettings GetHeroValidationSettings()
    {
        return new HeroValidationSettings()
        {
            NickNameTasks = new List<IStringValidationTask>()
            {
                new IsNotNull(),
                new StringMinLength(3),
                new StringMaxLength(20),
                new RestrictedWords(),
                new AllowedCharacters("abcdefghijklmnopqrstuvwxyz ")
            },
            AvatarTasks = new List<INumberValidationTask>()
            {
                new NumberNotNull(),
                new NumberRange(1, 7)
            },
            ProfessionTasks = new List<INumberValidationTask>()
            {
                new NumberNotNull(),
                new NumberRange(
                    Enum.GetNames(typeof(HeroProfession)).Min(hp=>(decimal)Enum.Parse<HeroProfession>(hp)),
                    Enum.GetNames(typeof(HeroProfession)).Max(hp=>(decimal)Enum.Parse<HeroProfession>(hp)))
            },
            AlredyInUseTask = new AlredyInUse()
        };
    }

    public static ItemValidationSettings GetItemValidationSettings()
    {
        return new ItemValidationSettings()
        {
            NameTasks = new List<IStringValidationTask>()
                {
                    new IsNotNull(),
                    new StringMinLength(3),
                    new StringMaxLength(50),
                    new RestrictedWords(),
                    new AllowedCharacters("abcdefghijklmnopqrstuvwxyz ()-+=/:&!")
                },
            TypeTasks = new List<INumberValidationTask>()
                {
                    new NumberNotNull(),
                    new NumberRange(0, 10)
                },
            RestrictionsTasks = new List<INumberValidationTask>()
                {
                    new NumberNotNull(),
                    new NumberRange(
                        Enum.GetNames(typeof(ProfessionRestriction)).Min(hp=>(decimal)Enum.Parse<ProfessionRestriction>(hp)),
                        Enum.GetNames(typeof(ProfessionRestriction)).Max(hp=>(decimal)Enum.Parse<ProfessionRestriction>(hp)))
                },
            TierTasks = new List<INumberValidationTask>()
                {
                    new NumberNotNull(),
                    new NumberRange(1, 10)
                },
            BuyPriceTasks = new List<INumberValidationTask>()
                {
                    new NumberNotNull(),
                    new NumberRange(0, 100_000)
                },
            SellPriceTasks = new List<INumberValidationTask>()
                {
                    new NumberNotNull(),
                    new NumberRange(0, 100_000)
                },
            DamageTasks = new List<INumberValidationTask>()
                {
                    new NumberNotNull(),
                    new NumberRange(-10, 50)
                },
            PrecisionTasks = new List<INumberValidationTask>()
                {
                    new NumberNotNull(),
                    new NumberRange(-10, 50)
                },
            SpecializationTasks = new List<INumberValidationTask>()
                {
                    new NumberNotNull(),
                    new NumberRange(-10, 50)
                },
            MaxHealthTasks = new List<INumberValidationTask>()
                {
                    new NumberNotNull(),
                    new NumberRange(0, 500)
                },
            ReflexTasks = new List<INumberValidationTask>()
                {
                    new NumberNotNull(),
                    new NumberRange(-10, 50)
                },
            DefenseTasks = new List<INumberValidationTask>()
                {
                    new NumberNotNull(),
                    new NumberRange(-10, 50)
                },
            AlredyInUseTask = new AlredyInUse()
        };
    }
}