using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizards.Core.Model.UserModels;

namespace Wizards.Services.SearchService
{
    public class PlayerForRankingDto
    {
        public int RankingNumber { get; set; }
        public Player Player { get; set; }
    }
}
