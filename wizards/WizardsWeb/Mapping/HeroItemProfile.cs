using AutoMapper;
using Wizards.Core.Model;
using Wizards.Core.Model.ManyToManyTables;
using Wizards.Services.Helpers;
using WizardsWeb.ModelViews.Inventory;
using WizardsWeb.ModelViews.Inventory.Properties;

namespace WizardsWeb.Mapping;

public class HeroItemProfile : Profile
{

    public HeroItemProfile()
    {
        CreateMap<ItemAttributes, ItemAttributesDetailsModelView>()
            .ForMember(dto => dto.MaxHealth, exp => exp.MapFrom(s => s.Item.Attributes.MaxHealth));

        CreateMap<HeroItem, HeroItemDetailsModelView>()
            .ForMember(dto => dto.Name, exp => exp.MapFrom(s => s.Item.Name))
            .ForMember(dto => dto.Type, exp => exp.MapFrom(s => s.Item.Type))
            .ForMember(dto => dto.Restriction, exp => exp.MapFrom(s => s.Item.Restriction))
            .ForMember(dto => dto.Tier, exp => exp.MapFrom(s => s.Item.Tier))
            .ForMember(dto => dto.Endurance, exp => exp.MapFrom(s => s.ItemEndurance))
            .ForMember(dto => dto.SellPrice, exp => exp.MapFrom(s => s.GetCalculatedSellPrice()))
            .ForMember(dto => dto.RepairCost, exp => exp.MapFrom(s => s.GetCalculatedRepairCost()))
            .ForMember(dto => dto.Equipped, exp => exp.MapFrom(s => s.InUse))
            .ForMember(dto => dto.Attributes, exp => exp.MapFrom(s => s.Item.Attributes));
    }

}