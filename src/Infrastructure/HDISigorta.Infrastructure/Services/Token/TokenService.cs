using HDISigorta.Application.Abstractions.Token;
using HDISigorta.Application.Dtos.AppUser.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace HDISigorta.Infrastructure.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenDto CreateAccessToken(int minute)
        {
            TokenDto token = new();

            //Security key in simetriğini alıyoruz.
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            //Şifrelenmiş kimliğini oluşturuyoruz.
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            //Oluşturulacak token ayarları verilir.
            token.Expiration = DateTime.UtcNow.AddMinutes(minute);
            JwtSecurityToken securityToken = new(
                audience : _configuration["Token:Audience"],
                issuer : _configuration["Token:Issuer"],
                expires : token.Expiration,
                notBefore : DateTime.UtcNow, //Token üretildiği anda devreye girmesini sağlar.
                signingCredentials : signingCredentials
                );

            //Token oluşturucu sınıfından token oluşturulur.
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
