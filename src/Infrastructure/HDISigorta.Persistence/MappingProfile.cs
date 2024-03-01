using AutoMapper;
using HDISigorta.Application.Dtos.Agreements;
using HDISigorta.Application.Dtos.ProductHistory;
using HDISigorta.Application.Dtos.Products;
using HDISigorta.Domain.Entities.Agreements;
using HDISigorta.Domain.Entities.Products;
using System.Collections.Generic;

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

            CreateMap<ProductHistory, GetProductHistoryByProductIdResponseDto>();
            CreateMap<GetProductHistoryByProductIdResponseDto, ProductHistory>();
        }
    }
}
