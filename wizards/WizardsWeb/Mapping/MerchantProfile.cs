using AutoMapper;
using Wizards.Core.Model;
using WizardsWeb.ModelViews.Merchant;

namespace WizardsWeb.Mapping;

public class MerchantProfile : Profile
{
    public MerchantProfile()
    {
        CreateMap<Item, ItemDetailsModelView>();
    }
    
}