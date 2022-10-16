using Wizards.Core.Model.WorldModels.Properties;

namespace Wizards.GamePlay.ResultLogService;

public interface IResultLogService
{
    public Task<RoundLog> CreateRoundLogAsync(RoundResult roundResult);
}