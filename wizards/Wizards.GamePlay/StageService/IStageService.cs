using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Model.WorldModels;

namespace Wizards.GamePlay.StageService
{
    public interface IStageService
    {
        public void CreateNewMatch(CombatStage stage, int enemyId, int heroId);

        public void CommitRound(CombatStage stage);  

        public void FinishMatch(CombatStage stage);
    }
}
