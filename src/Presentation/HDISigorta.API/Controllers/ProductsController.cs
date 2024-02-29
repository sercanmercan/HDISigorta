using AutoMapper;
using HDISigorta.Application.Dtos.Products;
using HDISigorta.Application.Repositories.Products;
using HDISigorta.Domain.Entities.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HDISigorta.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        public ProductsController(
            IMapper mapper,
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Tüm ürünleri listeler.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ProductResponseDto> GetAllProduct()
        {
            List<Product> productList = _productReadRepository.GetAll(false).ToList();
            List<ProductResponseDto> map = _mapper.Map<List<Product>, List<ProductResponseDto>>(productList);
            return map;
        }

        /// <summary>
        /// Id ye göre ürünü getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id, false);
            return Ok(product);
        }

        /// <summary>
        /// Ürünüekleme işlemi yaptırır.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateProductRequestDto request)
        {
            string resultErrorMessage = string.Empty;
            try
            {
                if (!request.IsCheckValid())
                {
                    resultErrorMessage = "Lütfen zorunlu alanları doldurunuz.";
                    throw new ArgumentException(resultErrorMessage);
                }

                await _productWriteRepository.AddAsync(new()
                {
                    Name = request.Name,
                    BuyingPrice = request.BuyingPrice,
                    SellingPrice = request.SellingPrice,
                    AgreementId = request.AgreementId,
                    IsChangedPart = request.IsChangedPart,
                    IsRepairedPart = request.IsRepairedPart,
                    RepairedPartCost = request.RepairedPartCost,
                    ChangedPartCost = request.ChangedPartCost,
                    BuyingTime = DateTime.Now
                });

                await _productWriteRepository.SaveAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultErrorMessage) ? resultErrorMessage : "Bir hata olustu");
            }
        }

        /// <summary>
        /// id ye göre gelen ürünü güncelleme işlemi yapar.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        [HttpPut]
        public async Task<bool> UpdateAsync(UpdateProductRequestDto request)
        {
            string resultErrorMessage = string.Empty;

            try
            {
                if (!request.IsCheckValid())
                {
                    resultErrorMessage = "Lütfen bilgileri giriniz.";
                    throw new ArgumentException(resultErrorMessage);
                }

                Product product = await _productReadRepository.GetByIdAsync(request.Id, true);

                if (product is null)
                {
                    resultErrorMessage = "Böyle bir ürün yok.";
                    throw new ArgumentException(resultErrorMessage);
                }

                product.Name = request.Name;
                product.BuyingPrice = request.BuyingPrice;
                product.SellingPrice = request.SellingPrice;
                product.AgreementId = request.AgreementId;
                product.IsChangedPart = request.IsChangedPart;
                product.IsRepairedPart = request.IsRepairedPart;
                product.RepairedPartCost = request.RepairedPartCost;
                product.ChangedPartCost = request.ChangedPartCost;
                //product.ProfitCost = request.ProfitCost;
                //product.ProfitMargin = request.ProfitMargin;

                _productWriteRepository.Update(product);
                await _productWriteRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultErrorMessage) ? resultErrorMessage : "Bir hata olustu");
            }
        }

        /// <summary>
        /// Id ye göre gelen ürünü isdeleted kolonunu true yaparak soft delete işlemi yapar.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        [HttpDelete("{id}")]
        public async Task<bool> DeleteProductAsync(Guid id)
        {
            string resultErrorMessage = string.Empty;

            try
            {
                Product? product = await _productReadRepository.GetByIdAsync(id);

                if (product is null)
                {
                    resultErrorMessage = "Böyle bir ürün yok.";
                    throw new ArgumentException(resultErrorMessage);
                }

                product.IsDeleted = true;
                product.DeletedDate = DateTime.Now;
                _productWriteRepository.Update(product);
                await _productWriteRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultErrorMessage) ? resultErrorMessage : "Bir hata olustu");
            }
        }
    }
}
