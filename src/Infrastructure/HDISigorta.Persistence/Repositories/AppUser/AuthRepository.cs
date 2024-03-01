using HDISigorta.Application.Abstractions.Token;
using HDISigorta.Application.Dtos.AppUser.CreateUser;
using HDISigorta.Application.Dtos.AppUser.LoginUser;
using HDISigorta.Application.Dtos.AppUser.Token;
using HDISigorta.Application.Exceptions;
using HDISigorta.Application.Repositories.AppUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace HDISigorta.Persistence.Repositories.AppUser
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<Domain.Entities.Identities.AppUser> _userManager;
        private readonly SignInManager<Domain.Entities.Identities.AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        public AuthRepository(UserManager<Domain.Entities.Identities.AppUser> userManager,
            SignInManager<Domain.Entities.Identities.AppUser> signInManager,
            ITokenService tokenService) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<CreateUserCommandResponseDto> CreateAsync(CreateUserCommandRequestDto request)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid(),
                UserName = request.UserName,
                Email = request.Email,
                FullName = request.NameSurname
            }, request.Password);

            if (result.Succeeded)
                return new()
                {
                    Succeeded = true,
                    Message = "Kullanıcı basariyla olusturulmustur."
                };

            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("dictionary.json", optional: true, reloadOnChange: true)
            .Build();

            throw new UserCreateFailedException(config["Exception:UserCreateFailedException"]);
        }

        public async Task<LoginUserResponseDto> LoginUser(LoginUserRequestDto loginUserRequestDto)
        {
            Domain.Entities.Identities.AppUser user = await _userManager.FindByNameAsync(loginUserRequestDto.UserNameOrEmail);
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("dictionary.json", optional: true, reloadOnChange: true)
            .Build();

            if (user is null)
                user = await _userManager.FindByEmailAsync(loginUserRequestDto.UserNameOrEmail);

            if (user is null)
                throw new NotFoundUserException(config["Exception:NotFoundUserException"]);

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, loginUserRequestDto.Password, false);

            if (result.Succeeded) // Authentication başarılıdır.
            {
                //Token alma işlemi yapılır.
                TokenDto token = _tokenService.CreateAccessToken(60);

                return new LoginUserSuccessResponseDto()
                {
                    LoginInfo = token,
                };
            }

            return new LoginUserErrorResponseDto()
            {
                Message = config["Exception:ErrorIdentity"]
            };
        }
    }
}
