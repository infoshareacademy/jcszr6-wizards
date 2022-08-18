using System.Collections.Generic;
using WizardsWeb.ModelViews.Inventory;

namespace WizardsWeb.ModelViews.Merchant;

public class HeroStorageModelView
{
    public int Gold { get; set; }
    public List<HeroItemDetailsModelView> Weapons { get; set; }
    public List<HeroItemDetailsModelView> Armors { get; set; }
    public List<HeroItemDetailsModelView> Miscellaneous { get; set; }

    public HeroStorageModelView()
    {
        Weapons = new List<HeroItemDetailsModelView>();
        Armors = new List<HeroItemDetailsModelView>();
        Miscellaneous = new List<HeroItemDetailsModelView>();
    }
}