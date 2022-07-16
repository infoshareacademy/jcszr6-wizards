using Wizards.Core.Interfaces;
using Wizards.Core.Model;
using Wizards.Services.Validation.Elements;
using Wizards.Services.Validation.Settings;

namespace Wizards.Services.Validation;

public class HeroValidator : IHeroValidator
{
    private readonly HeroValidationSettings _settings;
    private Dictionary<string, string> _modelStatesData;
    private bool _isValid;
    private readonly IHeroRepository _heroRepository;

    public HeroValidator(IHeroRepository heroRepository)
    {
        _settings = ValidationSettingsFactory.GetHeroValidationSettings();
        _modelStatesData = new Dictionary<string, string>();
        _heroRepository = heroRepository;
    }

    public async Task Validate(Hero hero)
    {
        _isValid = true;

        if (!await _heroRepository.Exist(hero.Id, hero.NickName))
        {
            ValidateNickName(hero.NickName);
            await NickNameInUse(hero.NickName);
        }
        ValidateAvatar(hero.AvatarImageNumber);
        ValidateProfession((int)hero.Profession);

        if (!_isValid)
        {
            throw new InvalidModelException(_modelStatesData);
        }
    }

    private void ValidateNickName(string heroNickName)
    {
        foreach (var task in _settings.NickNameTasks)
        {
            var result = task.Validate(heroNickName);

            if (!result.IsValid)
            {
                _isValid = false;
                _modelStatesData.Add("NickName", $"Nick Name {result.Message}");
                return;
            }
        }
    }

    private void ValidateProfession(int heroProfession)
    {
        foreach (var task in _settings.ProfessionTasks)
        {
            var result = task.Validate(heroProfession);

            if (!result.IsValid)
            {
                _isValid = false;
                _modelStatesData.Add("Profession", $"Profession {result.Message}");
                return;
            }
        }

    }

    private void ValidateAvatar(int heroAvatarImageNumber)
    {
        foreach (var task in _settings.AvatarTasks)
        {
            var result = task.Validate(heroAvatarImageNumber);

            if (!result.IsValid)
            {
                _isValid = false;
                _modelStatesData.Add("AvatarImageNumber", $"Avatar image number {result.Message}");
                return;
            }
        }
    }

    private async Task NickNameInUse(string heroNickName)
    {
        var inUseNickname = _settings.AlredyInUseTask.Validate(heroNickName,
            await _heroRepository.GetAllNickNames());

        if (!inUseNickname.IsValid)
        {
            _isValid = false;
            _modelStatesData.Add("NickName", $"Nick Name {inUseNickname.Message}");
        }
    }
}