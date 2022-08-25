using Microsoft.AspNetCore.Identity;
using Wizards.Core.Model.WorldModels;

namespace Wizards.Core.Model.UserModels;

public class Player : IdentityUser<int>
{
    public int ActiveHeroId { get; set; }
    public int ActiveItemId { get; set; }

    public DateTime DateOfBirth { get; set; }

    public List<Hero> Heroes = new();

    public CombatStage CombatStage { get; set; }
}