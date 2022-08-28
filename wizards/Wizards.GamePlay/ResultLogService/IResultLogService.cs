using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.GamePlay.CombatService;

namespace Wizards.GamePlay.ResultLogService
{
    public interface IResultLogService
    {
        public string CreateRoundLog(RoundResult roundResult);
    }
}
