using AutoMapper;
using HDISigorta.Application.Dtos.Agreements;
using HDISigorta.Application.Dtos.AppUser.CreateUser;
using HDISigorta.Application.Dtos.Dealers;
using HDISigorta.Application.Repositories.AppUser;
using HDISigorta.Application.Repositories.Dealers;
using HDISigorta.Domain.Entities.Agreements;
using HDISigorta.Domain.Entities.Dealers;
using HDISigorta.Persistence.Repositories.Dealers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HDISigorta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDealerReadRepository _dealerReadRepository;
        private readonly IDealerWriteRepository _dealerWriteRepository;
        private readonly IAuthRepository _authRepository;
        public DealerController(IMapper mapper,
            IDealerReadRepository dealerReadRepository,
            IDealerWriteRepository dealerWriteRepository,
            IAuthRepository authRepository)
        {
            _mapper = mapper;
            _dealerReadRepository = dealerReadRepository;
            _dealerWriteRepository = dealerWriteRepository;
            _authRepository = authRepository;
        }

        /// <summary>
        /// Bayileri listeler.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<DealerResponseDto> GetAllProduct()
        {
            var DealerList = _dealerReadRepository.GetAll(false).ToList();
            List<DealerResponseDto> map = _mapper.Map<List<Dealer>, List<DealerResponseDto>>(DealerList);
            return map;
        }

        /// <summary>
        /// Id ye göre bayiyi getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            Dealer dealer = await _dealerReadRepository.GetByIdAsync(id, false);
            return Ok(dealer);
        }

        /// <summary>
        /// Bayi ekleme işlemi yaptırır.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateDealerRequestDto request)
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

                await _dealerWriteRepository.AddAsync(new()
                {
                    Id = Guid.NewGuid(),
                    FullAdress = request.FullAdress,
                    DealerName = request.DealerName
                });

                await _dealerWriteRepository.SaveAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultErrorMessage) ? resultErrorMessage : config["Exception:ErrorOccured"]);
            }
        }

        /// <summary>
        /// id ye göre gelen bayiyi güncelleme işlemi yapar.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        [HttpPut]
        public async Task<bool> UpdateAsync(UpdateDealerRequestDto request)
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

                Dealer dealer = await _dealerReadRepository.GetByIdAsync(request.Id, true);

                if (dealer is null)
                {
                    resultErrorMessage = config["Exception:NoDealer"];
                    throw new ArgumentException(resultErrorMessage);
                }

                dealer.DealerName = request.DealerName;
                dealer.FullAdress = request.FullAdress;
                
                _dealerWriteRepository.Update(dealer);
                await _dealerWriteRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultErrorMessage) ? resultErrorMessage : config["Exception:ErrorOccured"]);
            }
        }
    }
}
