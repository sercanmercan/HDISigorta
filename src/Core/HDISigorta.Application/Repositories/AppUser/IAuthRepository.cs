using HDISigorta.Application.Dtos.AppUser.CreateUser;
using HDISigorta.Application.Dtos.AppUser.LoginUser;

namespace HDISigorta.Application.Repositories.AppUser
{
    public interface IAuthRepository
    {
        Task<CreateUserCommandResponseDto> CreateAsync(CreateUserCommandRequestDto request);
        Task<LoginUserResponseDto> LoginUser(LoginUserRequestDto loginUserRequestDto);
    }
}
