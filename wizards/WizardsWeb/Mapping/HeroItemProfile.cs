using AutoMapper;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Properties;
using Wizards.Core.ModelExtensions;
using WizardsWeb.ModelViews.ItemModelViews;
using WizardsWeb.ModelViews.ItemModelViews.Properties;

namespace WizardsWeb.Mapping;

public class HeroItemProfile : Profile
{

    public HeroItemProfile()
    {
        CreateMap<ItemAttributes, ItemAttributesDetailsModelView>()
            .ForMember(dto => dto.MaxHealth, exp => exp.MapFrom(s => s.Item.Attributes.MaxHealth));

        CreateMap<HeroItem, ItemDetailsModelView>()
            .ForMember(dto => dto.Id, exp => exp.MapFrom(s => s.Id))
            .ForMember(dto => dto.CoreItemId, exp => exp.MapFrom(s => -s.Item.Id))
            .ForMember(dto => dto.IsMerchantItem, exp => exp.MapFrom(s => false))
            .ForMember(dto => dto.IsInMerchantMode, exp => exp.MapFrom(s => false))
            .ForMember(dto => dto.Name, exp => exp.MapFrom(s => s.Item.Name))
            .ForMember(dto => dto.Type, exp => exp.MapFrom(s => s.Item.Type))
            .ForMember(dto => dto.Restriction, exp => exp.MapFrom(s => s.Item.Restriction))
            .ForMember(dto => dto.Tier, exp => exp.MapFrom(s => s.Item.Tier))
            .ForMember(dto => dto.IsEquipped, exp => exp.MapFrom(s => s.InUse))
            .ForMember(dto => dto.Attributes, exp => exp.MapFrom(s => s.Item.Attributes))
            .ForMember(dto => dto.Endurance, exp => exp.MapFrom(s => s.ItemEndurance))
            .ForMember(dto => dto.RepairCost, exp => exp.MapFrom(s => s.GetCalculatedRepairCost()))
            .ForMember(dto => dto.SellPrice, exp => exp.MapFrom(s => s.GetCalculatedSellPrice()))
            .ForMember(dto => dto.BuyPrice, exp => exp.MapFrom(s => s.Item.BuyPrice));

        CreateMap<Item, ItemDetailsModelView>()
            .ForMember(dto => dto.Id, exp => exp.MapFrom(s => -s.Id))
            .ForMember(dto => dto.CoreItemId, exp => exp.MapFrom(s => s.Id))
            .ForMember(dto => dto.IsMerchantItem, exp => exp.MapFrom(s => true))
            .ForMember(dto => dto.IsInMerchantMode, exp => exp.MapFrom(s => true))
            .ForMember(dto => dto.IsEquipped, exp => exp.MapFrom(s => false))
            .ForMember(dto => dto.Attributes, exp => exp.MapFrom(s => s.Attributes))
            .ForMember(dto => dto.Endurance, exp => exp.MapFrom(s => 100d))
            .ForMember(dto => dto.RepairCost, exp => exp.MapFrom(s => 0));
    }
}