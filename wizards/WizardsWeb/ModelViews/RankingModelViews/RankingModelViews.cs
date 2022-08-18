using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WizardsWeb.ModelViews.RankingModelViews;

public class RankingModelViews
{
    public List<PlayerDetailsDto> PlayerDetailsDto;

    [Display(Name = "User Name")]
    [MinLength(3)]
    [MaxLength(20)]
    public string UserName { get; set; }
  
    [Display(Name = "Rank points")]
    
    public int FromRankPoints { get; set; }
    public int ToRankPoints { get; set; }

    [Display(Name = "Email")]
    [EmailAddress]
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
