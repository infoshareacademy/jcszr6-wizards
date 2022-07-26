using Wizards.Core.Interfaces;
using Wizards.Core.Model;
using Wizards.Core.Model.Enums;
using Wizards.Services.Validation.Elements;
using Wizards.Services.Validation.Settings;
using Wizards.Services.Validation.ValidationTasks.Interfaces;

namespace Wizards.Services.Validation
{
    public class ItemValidator : IItemValidator
    {
        private readonly ItemValidationSettings _settings;
        private Dictionary<string, string> _modelStatesData;
        private bool _isValid;
        private readonly IItemRepository _itemRepository;

        public ItemValidator(IItemRepository itemRepository)
        {
            _settings = ValidationSettingsFactory.GetItemValidationSettings();
            _modelStatesData = new Dictionary<string, string>();
            _itemRepository = itemRepository;
        }
        public async Task Validate(Item item)
        {
            ValidateName(item.Name);

            ValidateType(item.Type);

            ValidateRestriction(item.Restriction);

            ValidateTier(item.Tier);

            ValidateBuyPrice(item.BuyPrice);

            ValidateSellPrice(item.SellPrice);

            ValidateAttributes(item.Attributes);

            await ValidateNameInUse(item.Name);
        }      

        private void ValidateName(string name)
        {
            foreach (var task in _settings.NameTasks)
            {
                var result = task.Validate(name);

                if (!result.IsValid)
                {
                    _isValid = false;
                    _modelStatesData.Add("Name", $"Name {result.Message}");
                    return;
                }
            }
        }
        private void ValidateType(ItemType type)
        {
            foreach (var task in _settings.TypeTasks)
            {
                var result = task.Validate((int)type);

                if (!result.IsValid)
                {
                    _isValid = false;
                    _modelStatesData.Add("Type", $"Type {result.Message}");
                    return;
                }
            }
        }
        private void ValidateRestriction(ProfessionRestriction restriction)
        {
            foreach (var task in _settings.RestrictionsTasks)
            {
                var result = task.Validate((int)restriction);

                if (!result.IsValid)
                {
                    _isValid = false;
                    _modelStatesData.Add("Restriction", $"Restriction {result.Message}");
                    return;
                }
            }
        }
        private void ValidateTier(int tier)
        {
            foreach (var task in _settings.TierTasks)
            {
                var result = task.Validate((int)tier);

                if (!result.IsValid)
                {
                    _isValid = false;
                    _modelStatesData.Add("Tier", $"Tier {result.Message}");
                    return;
                }
            }
        }
        private void ValidateBuyPrice(int buyPrice)
        {
            foreach (var task in _settings.BuyPriceTasks)
            {
                var result = task.Validate((int)buyPrice);

                if (!result.IsValid)
                {
                    _isValid = false;
                    _modelStatesData.Add("BuyPrice", $"BuyPrice {result.Message}");
                    return;
                }
            }
        }
        private void ValidateSellPrice(int sellPrice)
        {
            foreach (var task in _settings.SellPriceTasks)
            {
                var result = task.Validate((int)sellPrice);

                if (!result.IsValid)
                {
                    _isValid = false;
                    _modelStatesData.Add("SellPrice", $"SellPrice {result.Message}");
                    return;
                }
            }
        }
        private void ValidateSingleAttribute(int value, List<INumberValidationTask> singleAttributeTasks, string propertyName)
        {
            foreach (var task in singleAttributeTasks)
            {
                var result = task.Validate((int)value);

                if (!result.IsValid)
                {
                    _isValid = false;
                    _modelStatesData.Add(propertyName, $"{propertyName} { result.Message}");
                    return;
                }
            }
        }
        private void ValidateAttributes(ItemAttributes attributes)
        {
            ValidateSingleAttribute(attributes.Damage, _settings.DamageTasks, "Damage");
            ValidateSingleAttribute(attributes.Precision, _settings.PrecisionTasks, "Precision");
            ValidateSingleAttribute(attributes.Specialization, _settings.SpecializationTasks, "Specialization");
            ValidateSingleAttribute(attributes.MaxHealth, _settings.MaxHealthTasks, "Max Health");
            ValidateSingleAttribute(attributes.CurrentHealth, _settings.CurrentHealthTasks, "Current Health");
            ValidateSingleAttribute(attributes.Reflex, _settings.ReflexTasks, "Reflex");
            ValidateSingleAttribute(attributes.Defense, _settings.DefenseTasks, "Defense");
        }
        private async Task ValidateNameInUse(string name)
        {
            var inUseName = _settings.AlredyInUseTask.Validate(name, await _itemRepository.GetAllNames());
            if (!inUseName.IsValid)
            {
                _isValid = false;
                _modelStatesData.Add("Name", $"Name {inUseName.Message}");
            }
        }
    }
}
