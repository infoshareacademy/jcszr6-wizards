using Wizards.Services.Validation.Elements;
using Wizards.Services.Validation.ValidationTasks;
using Wizards.Services.Validation.ValidationTasks.Interfaces;

namespace Wizards.Services.Validation.Settings
{
    public static class ValidationSettingsFactory
    {
        private static PlayerValidationSettings _playerSettings;
        private static HeroValidationSettings _heroSettings;
        private static ItemValidationSettings _itemSettings;

        static ValidationSettingsFactory()
        {
            _playerSettings = new PlayerValidationSettings()
            {
                UserNameTasks = new List<IStringValidationTask>()
                {
                    new IsNull(),
                    new StringMinLength(3),
                    new StringMaxLength(20),
                    new RestrictedWords(),
                    new AllowedCharacters("abcdefghijklmnopqrstuvwxyz1234567890-_"),
                },
                AlredyInUseTask = new AlredyInUse(),
                PasswordTasks = new List<IStringValidationTask>()
                {
                    new IsNull(),
                    new StringMinLength(8),
                    new AllowedCharacters("abcdefghijklmnopqrstuvwxyz1234567890,.;:?!'@#$%^&*()_+-=`~"),
                    new IsPasswordHardEnough()
                },
                EmailTasks = new List<IStringValidationTask>()
                {
                    new IsNull(),
                    new IsEmail()
                },
                DateOfBirthTasks = new List<IDateValidationTask>()
                {
                    new DateMin(new DateTime(1900, 1, 1)),
                    new RestrictedAge(10)
                }
            };

            _heroSettings = new HeroValidationSettings()
            {
                NickNameTasks = new List<IStringValidationTask>()
                {
                    new IsNull(),
                    new StringMinLength(3),
                    new StringMaxLength(20),
                    new RestrictedWords(),
                    new AllowedCharacters("abcdefghijklmnoprstuvwxyz ")
                },
                AvatarTasks = new List<INumberValidationTask>()
                {
                    new NumberRange(1, 7)
                },
                ProfessionTasks = new List<INumberValidationTask>()
                {
                    new NumberRange(0, 1)
                },
                AlredyInUseTask = new AlredyInUse()
            };

            _itemSettings = new ItemValidationSettings()
            {
                NameTasks = new List<IStringValidationTask>()
                {
                    new IsNull(),
                    new StringMinLength(3),
                    new StringMaxLength(50),
                    new RestrictedWords(),
                    new AllowedCharacters("abcdefghijklmnoprstuvwxyz ()-+=/:")
                },
                TypeTasks = new List<INumberValidationTask>()
                {
                    new NumberRange(0, 10)
                },
                RestrictionsTasks = new List<INumberValidationTask>()
                {
                    new NumberRange(0, 10)
                },
                TierTasks = new List<INumberValidationTask>()
                {
                    new NumberRange(1, 5)
                },
                BuyPriceTasks = new List<INumberValidationTask>()
                {
                    new NumberRange(0, 100_000)
                },
                SellPriceTasks = new List<INumberValidationTask>()
                {
                    new NumberRange(0, 100_000)
                },
                DamageTasks = new List<INumberValidationTask>()
                {
                    new NumberRange(-10, 50)
                },
                PrecisionTasks = new List<INumberValidationTask>()
                {
                    new NumberRange(-10, 50)
                },
                SpecializationTasks = new List<INumberValidationTask>()
                {
                    new NumberRange(-10, 50)
                },
                MaxHealthTasks = new List<INumberValidationTask>()
                {
                    new NumberRange(0, 500)
                },
                ReflexTasks = new List<INumberValidationTask>()
                {
                    new NumberRange(-10, 50)
                },
                DefenseTasks = new List<INumberValidationTask>()
                {
                    new NumberRange(-10, 50)
                },
                AlredyInUseTask = new AlredyInUse()
            };
        }

        public static PlayerValidationSettings GetPlayersValidationSettings()
        {
            return _playerSettings;
        }

        public static HeroValidationSettings GetHeroValidationSettings()
        {
            return _heroSettings;
        }

        public static ItemValidationSettings GetItemValidationSettings()
        {
            return _itemSettings;
        }
    }
}