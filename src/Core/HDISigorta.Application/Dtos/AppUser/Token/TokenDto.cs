namespace HDISigorta.Application.Dtos.AppUser.Token
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
