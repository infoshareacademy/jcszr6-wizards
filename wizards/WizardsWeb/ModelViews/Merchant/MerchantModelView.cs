namespace WizardsWeb.ModelViews.Merchant;

public class MerchantModelView
{
    public HeroStorageModelView HeroStorage { get; set; }
    public MerchantStorageModelView MerchantStorage { get; set; }

    public MerchantModelView()
    {
        HeroStorage = new HeroStorageModelView();
        MerchantStorage = new MerchantStorageModelView();
    }
}