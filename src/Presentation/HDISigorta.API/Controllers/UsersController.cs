using HDISigorta.Application.Dtos.AppUser.CreateUser;
using HDISigorta.Application.Dtos.AppUser.LoginUser;
using HDISigorta.Application.Repositories.AppUser;
using Microsoft.AspNetCore.Mvc;

namespace HDISigorta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public UsersController(
            IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(CreateUserCommandRequestDto createUserCommandRequestDto)
        {
            CreateUserCommandResponseDto response = await _authRepository.CreateAsync(createUserCommandRequestDto);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> LoginAsync(LoginUserRequestDto loginUserRequestDto)
        {
            LoginUserResponseDto response = await _authRepository.LoginUser(loginUserRequestDto);
            return Ok(response);
        }
    }
}
