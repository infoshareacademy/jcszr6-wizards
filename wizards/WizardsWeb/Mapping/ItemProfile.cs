using AutoMapper;
using Wizards.Core.Model.UserModels;
using Wizards.Core.Model.UserModels.Properties;
using WizardsWeb.ModelViews.ItemModelViews;

namespace WizardsWeb.Mapping;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<ItemCreateModelView, Item>()
            .ForMember(dto => dto.Attributes, exp => exp.MapFrom(s => new ItemAttributes()
            {
                Damage = s.Damage,
                Precision = s.Precision,
                Specialization = s.Specialization,
                MaxHealth = s.MaxHealth,
                Reflex = s.Reflex,
                Defense = s.Defense
            }));

        CreateMap<ItemEditModelView, Item>()
            .ForMember(dto => dto.Attributes, exp => exp.MapFrom(s => new ItemAttributes()
            {
                Damage = s.Damage,
                Precision = s.Precision,
                Specialization = s.Specialization,
                MaxHealth = s.MaxHealth,
                Reflex = s.Reflex,
                Defense = s.Defense
            }));

        CreateMap<Item, ItemEditModelView>()
            .ForMember(dto => dto.Damage, exp => exp.MapFrom(s => s.Attributes.Damage))
            .ForMember(dto => dto.Precision, exp => exp.MapFrom(s => s.Attributes.Precision))
            .ForMember(dto => dto.Specialization, exp => exp.MapFrom(s => s.Attributes.Specialization))
            .ForMember(dto => dto.MaxHealth, exp => exp.MapFrom(s => s.Attributes.MaxHealth))
            .ForMember(dto => dto.Reflex, exp => exp.MapFrom(s => s.Attributes.Reflex))
            .ForMember(dto => dto.Defense, exp => exp.MapFrom(s => s.Attributes.Defense));
    }
}