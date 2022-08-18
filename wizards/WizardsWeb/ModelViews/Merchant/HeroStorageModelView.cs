using System.Collections.Generic;
using WizardsWeb.ModelViews.ItemModelViews;

namespace WizardsWeb.ModelViews.Merchant;

public class HeroStorageModelView
{
    public string HeroNickName { get; set; }
    public int Gold { get; set; }
    
    public List<ItemDetailsModelView> Weapons { get; set; }
    public List<ItemDetailsModelView> Armors { get; set; }
    public List<ItemDetailsModelView> Miscellaneous { get; set; }

    public HeroStorageModelView()
    {
        Weapons = new List<ItemDetailsModelView>();
        Armors = new List<ItemDetailsModelView>();
        Miscellaneous = new List<ItemDetailsModelView>();
    }
}