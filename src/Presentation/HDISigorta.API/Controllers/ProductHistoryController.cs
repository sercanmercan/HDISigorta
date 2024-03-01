using AutoMapper;
using HDISigorta.Application.Dtos.ProductHistory;
using HDISigorta.Application.Repositories.ProductHistory;
using HDISigorta.Domain.Entities.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HDISigorta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductHistoryController : ControllerBase
    {
        private readonly IProductHistoryReadRepository _productHistoryReadRepository;
        private readonly IMapper _mapper;
        public ProductHistoryController(IProductHistoryReadRepository productHistoryReadRepository,
            IMapper mapper)
        {
            _productHistoryReadRepository = productHistoryReadRepository;
            _mapper = mapper;
        }

        [HttpGet("{productId}")]
        public List<GetProductHistoryByProductIdResponseDto> GetProductHistoryByProductIdAsync(Guid productId)
        {
            List<ProductHistory> productHistory =  _productHistoryReadRepository.GetWhere(x => x.ProductId == productId).Include(x => x.Product).ToList();
            List<GetProductHistoryByProductIdResponseDto> mapping = _mapper.Map<List<ProductHistory>, List<GetProductHistoryByProductIdResponseDto>>(productHistory);
            return mapping;
        }
    }
}
