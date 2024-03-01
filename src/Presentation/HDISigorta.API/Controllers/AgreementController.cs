using AutoMapper;
using HDISigorta.Application.Dtos.Agreements;
using HDISigorta.Application.Repositories.Agreements;
using HDISigorta.Domain.Entities.Agreements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HDISigorta.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AgreementController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAgreementWriteRepository _agreementWriteRepository;
        private readonly IAgreementReadRepository _agreementReadRepository;
        public AgreementController(
            IMapper mapper,
            IAgreementWriteRepository agreementWriteRepository,
            IAgreementReadRepository agreementReadRepository)
        {
            _agreementWriteRepository = agreementWriteRepository;
            _agreementReadRepository = agreementReadRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Tüm garanti içeriklerini listeler.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<AgreementResponseDto> GetAllProduct()
        {
            List<Agreement> AgreementList = _agreementReadRepository.GetAll(false).ToList();
            List<AgreementResponseDto> map = _mapper.Map<List<Agreement>, List<AgreementResponseDto>>(AgreementList);
            return map;
        }

        /// <summary>
        /// Id ye göre garanti içeriğini getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            Agreement agreement = await _agreementReadRepository.GetByIdAsync(id, false);
            return Ok(agreement);
        }

        /// <summary>
        /// Garanti içeriği ekleme işlemi yaptırır.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateAgreementRequestDto request)
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

                await _agreementWriteRepository.AddAsync(new()
                {
                    Name = request.Name,
                    Description = request.Description,
                    ValidityPeriod = request.ValidityPeriod
                });

                await _agreementWriteRepository.SaveAsync();
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
        public async Task<bool> UpdateAsync(UpdateAgreementRequestDto request)
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

                Agreement agreement = await _agreementReadRepository.GetByIdAsync(request.Id, true);

                if (agreement is null)
                {
                    resultErrorMessage = config["Exception:NoProduct"];
                    throw new ArgumentException(resultErrorMessage);
                }

                agreement.Name = request.Name;
                agreement.ValidityPeriod = request.ValidityPeriod;
                agreement.Description = request.Description;

                _agreementWriteRepository.Update(agreement);
                await _agreementWriteRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultErrorMessage) ? resultErrorMessage : config["Exception:ErrorOccured"]);
            }
        }

        /// <summary>
        /// Id ye göre gelen garanti içeriğini isdeleted kolonunu true yaparak soft delete işlemi yapar.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        [HttpDelete("{id}")]
        public async Task<bool> DeleteAgreementAsync(Guid id)
        {
            string? resultErrorMessage = string.Empty;
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("dictionary.json", optional: true, reloadOnChange: true)
            .Build();

            try
            {
                Agreement? agreement = await _agreementReadRepository.GetByIdAsync(id);

                if (agreement is null)
                {
                    resultErrorMessage = config["Exception:NoProduct"];
                    throw new ArgumentException(resultErrorMessage);
                }

                agreement.IsDeleted = true;
                agreement.DeletedDate = DateTime.Now;
                _agreementWriteRepository.Update(agreement);
                await _agreementWriteRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(!string.IsNullOrWhiteSpace(resultErrorMessage) ? resultErrorMessage : config["Exception:ErrorOccured"]);
            }
        }
    }
}
