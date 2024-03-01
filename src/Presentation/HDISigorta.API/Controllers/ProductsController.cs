using AutoMapper;
using HDISigorta.Application.Abstractions.Helper;
using HDISigorta.Application.Abstractions.Hubs;
using HDISigorta.Application.Dtos.Helper;
using HDISigorta.Application.Dtos.Products;
using HDISigorta.Application.Exceptions;
using HDISigorta.Application.Repositories.Products;
using HDISigorta.Domain.Entities.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        private readonly IHelper _helper;
        private readonly IProductHubService _productHubService;
        public ProductsController(
            IMapper mapper,
            IHelper helper,
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            IProductHubService productHubService)
        {
            _mapper = mapper;
            _helper = helper;
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _productHubService = productHubService;
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
            string? resultErrorMessage = string.Empty;
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("dictionary.json", optional: true, reloadOnChange: true)
            .Build();

            try
            {
                if (!request.IsCheckValid())
                {
                    throw new RequiredAreaException(config["Exception:RequiredArea"]);
                }

                await _productWriteRepository.AddAsync(new()
                {
                    Name = request.Name,
                    BuyingPrice = request.BuyingPrice,
                    SellingPrice = request.SellingPrice,
                    AgreementId = request.AgreementId,
                    IsChangedPart = request.IsChangedPart,
                    IsRepairedPart = request.IsRepairedPart,
                    RepairOrChangedPartCost = request.RepairOrChangedPartCost,
                    BuyingTime = DateTime.Now,
                    ProductStatus = Domain.Entities.Enums.ProductStatusEnum.InStock
                });

                await _productWriteRepository.SaveAsync();
                await _productHubService.ProductAddedMessageAsync($"{request.Name} {config["Dictionary:AddProduct"]}");
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultErrorMessage) ? resultErrorMessage : config["Exception:ErrorOccured"]);
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
            string? resultErrorMessage = string.Empty;
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("dictionary.json", optional: true, reloadOnChange: true)
            .Build();

            try
            {
                if (!request.IsCheckValid())
                {
                    resultErrorMessage = config["Exception:RequiredArea"];
                    throw new ArgumentException(resultErrorMessage);
                }

                Product? product = _productReadRepository.GetWhere(x => x.Id == request.Id, true).Include(x => x.ProductHistories).FirstOrDefault();

                if (product is null)
                {
                    resultErrorMessage = config["Exception:NoProduct"];
                    throw new ArgumentException(resultErrorMessage);
                }

                //RepairOrChangedPartCost güncellendiyse  hesaplama yapılacak.
                if (request.RepairOrChangedPartCost > 0)
                {
                    var oldTotalRepairOrChangedPartCost = product.ProductHistories.Where(x => x.ProductId == request.Id).Select(x => x.TotalRepairOrChangedPartCost).LastOrDefault();

                    ProfitabilityRequestDto profitabilityRequestDto = new()
                    {
                        BuyingPrice = request.BuyingPrice,
                        SellingPrice = request.SellingPrice,
                        TotalRepairOrChangedPartCost = oldTotalRepairOrChangedPartCost
                    };

                    ProductHistory productHistory = new()
                    {
                        ProductId = request.Id,
                        ProfitCost = await _helper.CalculateProfitabilityCost(profitabilityRequestDto),
                        ProfitMargin = await _helper.CalculateProfitabilityRatio(profitabilityRequestDto),
                        RiskCost = await _helper.CalculateRiskCostRatio(new()
                        {
                            SellingPrice = request.SellingPrice,
                            TotalRepairOrChangedPartCost = request.RepairOrChangedPartCost + product.RepairOrChangedPartCost
                        }),
                        RepairOrChangedPartCost = request.RepairOrChangedPartCost,
                        TotalRepairOrChangedPartCost = request.RepairOrChangedPartCost + product.RepairOrChangedPartCost
                    };

                    product.ProductHistories.Add(productHistory);

                    product.Name = request.Name;
                    product.BuyingPrice = request.BuyingPrice;
                    product.SellingPrice = request.SellingPrice;
                    product.AgreementId = request.AgreementId;
                    product.IsChangedPart = request.IsChangedPart;
                    product.IsRepairedPart = request.IsRepairedPart;
                    product.RepairOrChangedPartCost = request.RepairOrChangedPartCost;
                }

                _productWriteRepository.Update(product);
                await _productWriteRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultErrorMessage) ? resultErrorMessage : config["Exception:ErrorOccured"]);
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
            string? resultErrorMessage = string.Empty;
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("dictionary.json", optional: true, reloadOnChange: true)
            .Build();

            try
            {
                Product? product = await _productReadRepository.GetByIdAsync(id);

                if (product is null)
                {
                    resultErrorMessage = config["Exception:NoProduct"];
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
                throw new Exception(!string.IsNullOrWhiteSpace(resultErrorMessage) ? resultErrorMessage : config["Exception:ErrorOccured"]);
            }
        }
    }
}