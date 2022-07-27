using AutoMapper;
using Wizards.Core.Model;
using WizardsWeb.ModelViews.ItemModelViews;

namespace WizardsWeb.Mapping
{
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
        }
    }
}
