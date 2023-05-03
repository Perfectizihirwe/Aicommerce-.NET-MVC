using AutoMapper;

namespace NetFullStack.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Entities.Order, Models.OrderDto>();
            CreateMap<Models.OrderDto, Entities.Order>();
        }
    }
}