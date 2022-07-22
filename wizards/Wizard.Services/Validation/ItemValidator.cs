using Wizards.Core.Interfaces;
using Wizards.Core.Model;
using Wizards.Core.Model.Enums;
using Wizards.Services.Validation.Elements;
using Wizards.Services.Validation.Settings;

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
            throw new NotImplementedException();
        }
    }
}
