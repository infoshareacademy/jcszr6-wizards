using System.Collections.Generic;
using WizardsWeb.ModelViews.ItemModelViews;

namespace WizardsWeb.ModelViews.Merchant;

public class MerchantStorageModelView
{
    public List<ItemDetailsModelView> Weapons { get; set; }
    public List<ItemDetailsModelView> Armors { get; set; }
    public List<ItemDetailsModelView> Miscellaneous { get; set; }
}