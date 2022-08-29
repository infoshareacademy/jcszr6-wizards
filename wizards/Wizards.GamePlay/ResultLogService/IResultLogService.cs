using Wizards.Core.Model.WorldModels.Properties;
using Wizards.GamePlay.CombatService;

namespace Wizards.GamePlay.ResultLogService
{
    public interface IResultLogService
    {
        public Task<RoundLog> CreateRoundLogAsync(RoundResult roundResult);
    }
}
