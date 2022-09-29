using Wizards.Core.Model.UserModels.Enums;

namespace WizardsWeb.ModelViews.HeroModelViews.Properties;

public class HeroBasicsModelView
{
    public string NickName { get; set; }
    public HeroProfession Profession { get; set; }
    public int AvatarImageNumber { get; set; }
    public string AvatarImageAddress => GetAvatarImageAddres();
    public string ProfessionImageAddress => GetProfessionImageAddres();

    public bool ShowButtons { get; set; }

    public HeroBasicsModelView()
    {
        ShowButtons = false;
    }

    private string GetAvatarImageAddres()
    {
        return $"Images/Hero/Avatars/Wizard-{AvatarImageNumber}.png";
    }
    public string GetProfessionImageAddres()
    {
        return $"Images/Hero/Professions/{Profession.ToString()}.png";
    }

}