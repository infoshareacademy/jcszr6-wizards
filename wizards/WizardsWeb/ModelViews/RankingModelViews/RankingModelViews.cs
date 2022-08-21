using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WizardsWeb.ModelViews.RankingModelViews;

public class RankingModelViews
{
    public List<PlayerDetailsDto> PlayerDetailsDto;

    [Display(Name = "User Name")]
    public string UserName { get; set; }

    [Display(Name = "Email")]
    public string Email { get; set; }
  
    [Display(Name = "Rank points from:")]
    public int FromRankPoints { get; set; }
    [Display(Name = "Rank points to:")]
    public int ToRankPoints { get; set; }

    public RankingModelViews(List<PlayerDetailsDto> playerDetailsDto)
    {
        PlayerDetailsDto = playerDetailsDto;
    }

    public RankingModelViews() { }
}