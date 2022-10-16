namespace Wizards.GamePlay.StageService;

public interface IStageService
{
    public Task CreateNewMatchAsync(int playerId, int enemyId);
    public Task CommitRoundAsync(int playerId, int selectedSkillId);
    public Task FinishMatchAsync(int playerId);
    public Task AbortMatchAsync(int playerId);
}