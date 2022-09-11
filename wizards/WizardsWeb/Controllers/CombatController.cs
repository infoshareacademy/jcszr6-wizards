using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wizards.Core.Interfaces.WorldModelInterfaces;
using Wizards.Core.Model.UserModels.Enums;
using Wizards.Core.Model.WorldModels.Enums;
using Wizards.Core.Model.WorldModels.Properties;
using Wizards.Core.Model.WorldModels.Properties.Enums;
using Wizards.GamePlay.StageService;
using Wizards.Services.Extentions;
using WizardsWeb.ModelViews.CombatModelViews;

namespace WizardsWeb.Controllers;

[Authorize]
public class CombatController : Controller
{
    private readonly IStageService _stageService;
    private readonly ICombatStageInstancesRepository _stageRepository;
    private readonly IMapper _mapper;

    public CombatController(IStageService stageService, ICombatStageInstancesRepository stageRepository, IMapper mapper)
    {
        _stageService = stageService;
        _stageRepository = stageRepository;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        //var combatStage = await _stageRepository.GetAsync(User.GetId());

        //var battleStage = _mapper.Map<CombatStageModelView>(combatStage);

        //combatStage.LastRoundResult = null;

        var battleStage = GetSpecialStageForTests();

        return View("CombatStage", battleStage);
    }

    public async Task<IActionResult> CreateNewMatch(int enemyId)
    {
        await _stageService.CreateNewMatchAsync(User.GetId(), enemyId, false);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> CommitRound(CombatStageModelView battleStage)
    {
        var nextHeroSkillId = battleStage.HeroSelectedSkillId;

        await _stageService.CommitRoundAsync(User.GetId(), nextHeroSkillId);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> FinishMatch()
    {
        await _stageService.FinishMatchAsync(User.GetId());

        return RedirectToAction("Details", "Hero");
    }

    private CombatStageModelView GetSpecialStageForTests()
    {
        var stage = new CombatStageModelView();

        stage.HeroSelectedSkillId = 1;
        stage.Name = "Lair of Legendary Dupa";
        stage.WasResultShown = false;
        stage.Status = StageStatus.DuringCombat;
        stage.IsTraining = false;
        stage.EnemySection = new EnemySectionModelView()
        {
            Name = "Legendary Dupa",
            AvatarImageNumber = 1,
            CurrentHealth = 250,
            MaxHealth = 500,
            SelectedSkillStunning = false,
            SelectedSkillType = EnemySkillType.Charge,
            IsStunned = true,
            Type = EnemyType.Boss
        };
        var skills = new List<HeroSkillModelView>()
        {
            new HeroSkillModelView(){Id = 10, Name = "Dupa Ognia", Type = HeroSkillType.Attack, SlotNumber = SkillSlotNumber.First, Description = "Throws fiery Dupa", Damage = 150, HitChance = 80, ArmorPenetrationPercent = 50, Healing = 0},
            new HeroSkillModelView(){Id = 20, Name = "Dupa Lodu", Type = HeroSkillType.CounterAttack, SlotNumber = SkillSlotNumber.Second, Description = "Throws Icy Dupa", Damage = 50, HitChance = 200, ArmorPenetrationPercent = 0, Healing = 0},
            new HeroSkillModelView(){Id = 30, Name = "Dupa Burzy", Type = HeroSkillType.Attack, SlotNumber = SkillSlotNumber.Third, Description = "Throws thunder Dupa", Damage = 150, HitChance = 80, ArmorPenetrationPercent = 75, Healing = 0},
            new HeroSkillModelView(){Id = 40, Name = "Dupa Blada", Type = HeroSkillType.Attack, SlotNumber = SkillSlotNumber.Fourth, Description = "Create Dupa's inferno", Damage = 150, HitChance = 80, ArmorPenetrationPercent = 0, Healing = 0},

            new HeroSkillModelView(){Id = 50, Name = "Dupa Leczenia", Type = HeroSkillType.Heal, SlotNumber = SkillSlotNumber.Fifth, Description = "Throws fiery Dupa", Damage = 150, HitChance = 80, ArmorPenetrationPercent = 50, Healing = 50},
            new HeroSkillModelView(){Id = 60, Name = "Dupa Tarczy", Type = HeroSkillType.Block, SlotNumber = SkillSlotNumber.Sixth, Description = "Blocks Dupa's Attack", Damage = 0, HitChance = 100, ArmorPenetrationPercent = 0, Healing = 0}
        };
        stage.HeroSection = new HeroSectionModelView()
        {
            NickName = "Dupa Slayer",
            AvatarImageNumber = 3,
            CurrentHealth = 200,
            MaxHealth = 250,
            IsStunned = false,
            Profession = HeroProfession.Sorcerer,
            Skills = skills
        };
        var lastResult = new RoundResult()
        {
            EnemySkillType = EnemySkillType.Charge,
            EnemyCombatStatus = EnemyCombatStatus.Countered,
            EnemyDamageTaken = 44,
            EnemyHealthRecovered = 1,
            EnemySkillName = "Kupa",
            EnemyWillBeStunned = false,
            EnemyName = "Legendary Dupa",
            HeroDamageTaken = 5,
            HeroHealthRecovered = 10,
            HeroSkillType = HeroSkillType.CounterAttack,
            HeroSkillName = "Dupa Lodu",
            HeroCombatStatus = HeroCombatStatus.HitsSuccessfully,
            HeroNickName = "Dupa Slayer",
            HeroWillBeStunned = false
        };
        stage.LastRoundResult = lastResult;
        stage.RoundLogs = new List<RoundLog>()
        {
            new RoundLog(){RoundNumber = 1, HeroActionLog = "Dupa Slayer hits Legendary Dupa with Dupa Blada (attack) and deals 200 damage.", EnemyActionLog = "Legendary Dupa mishits Dupa Slayer"},
            new RoundLog(){RoundNumber = 2, HeroActionLog = "Dupa Slayer hits Legendary Dupa with Dupa Blada (attack) and deals 200 damage.", EnemyActionLog = "Legendary Dupa mishits Dupa Slayer"},
            new RoundLog(){RoundNumber = 3, HeroActionLog = "Dupa Slayer hits Legendary Dupa with Dupa Blada (attack) and deals 200 damage.", EnemyActionLog = "Legendary Dupa mishits Dupa Slayer"},
            new RoundLog(){RoundNumber = 4, HeroActionLog = "Dupa Slayer hits Legendary Dupa with Dupa Blada (attack) and deals 200 damage.", EnemyActionLog = "Legendary Dupa mishits Dupa Slayer"},
        };
        return stage;
    }
}