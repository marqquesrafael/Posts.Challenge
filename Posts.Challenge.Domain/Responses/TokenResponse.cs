namespace Posts.Challenge.Domain.Responses
{
    public class TokenResponse
    {
        public TokenResponse()
        {
            TokenType = "Bearer";
        }

        public string Token { get; set; }

        public string TokenType { get; set; }

        public int ExpireIn { get; set; }
    }
}
