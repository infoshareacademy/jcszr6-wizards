using System;
using System.Collections.Generic;

namespace WizardsWeb.ModelViews.RankingModelViews;

public class RankingModelViews
{
    public List<PlayerDetailsDto> PlayerDetailsDto;

    public string UserName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public int ItemPersPage { get; set; }

    public RankingModelViews(List<PlayerDetailsDto> playerDetailsDto)
    {
        PlayerDetailsDto = playerDetailsDto;
        
    }

    public RankingModelViews()
    {
        
    }


}
