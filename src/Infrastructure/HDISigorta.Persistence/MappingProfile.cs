using AutoMapper;
using HDISigorta.Application.Dtos.Agreements;
using HDISigorta.Application.Dtos.Products;
using HDISigorta.Domain.Entities.Agreements;
using HDISigorta.Domain.Entities.Products;

namespace HDISigorta.Persistence
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductResponseDto, Product>();
            CreateMap<Product, ProductResponseDto>();

            CreateMap<AgreementResponseDto, Agreement>();
            CreateMap<Agreement, AgreementResponseDto>();
        }
    }
}
