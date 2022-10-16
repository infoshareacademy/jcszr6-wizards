using Microsoft.AspNetCore.Identity;

namespace Wizards.Core.Model.UserModels;

public class Player : IdentityUser<int>
{
    public int ActiveHeroId { get; set; }
    public int ActiveItemId { get; set; }

    public DateTime DateOfBirth { get; set; }
    public int MusicVolume { get; set; }

    public List<Hero> Heroes = new();
}