using AutoMapper;

namespace NetFullStack.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Entities.Product, Models.ProductDto>();
            CreateMap<Models.ProductDto, Entities.Product>();
        }
    }
}