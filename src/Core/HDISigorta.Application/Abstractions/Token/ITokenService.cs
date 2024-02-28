using HDISigorta.Application.Dtos.AppUser.Token;

namespace HDISigorta.Application.Abstractions.Token
{
    public interface ITokenService
    {
        TokenDto CreateAccessToken(int minute);
    }
}
