using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wizards.Core.Model;
using Wizards.Core.Model.UserModels;

namespace WizardsWeb.ModelViews.PlayerModelViews;

public class PlayerDetailsModelView
{
    [Display(Name = "User Name")]
    public string UserName { get; set; }

    [Display(Name = "Email addres")]
    [EmailAddress]
    public string Email { get; set; }

    [Display(Name = "Date of birth")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    public List<Hero> Heroes = new();
}