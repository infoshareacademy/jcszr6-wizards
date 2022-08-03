using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WizardsWeb.ModelViews.RankingModelViews;

public class RankingModelViews
{
    public List<PlayerDetailsDto> PlayerDetailsDto;


  
    public string UserName { get; set; }
  
    public int FromDate { get; set; }
   
    public int ToDate { get; set; }
   
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
