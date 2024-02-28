using HDISigorta.Application.Dtos.AppUser.Token;

namespace HDISigorta.Application.Dtos.AppUser.LoginUser
{
    public class LoginUserResponseDto
    {
    }

    public class LoginUserSuccessResponseDto : LoginUserResponseDto
    {
        public TokenDto LoginInfo { get; set; }

    }

    public class LoginUserErrorResponseDto : LoginUserResponseDto
    {
        public string Message { get; set; }
    }
}
