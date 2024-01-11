namespace Posts.Challenge.Domain.Configuration.Jwt
{
    public class JWTConfiguration
    {
        public string Secret { get; set; }

        public int ExpirationInHour { get; set; }

        public string EmitedBy { get; set; }

        public string ValidatedIn { get; set; }
    }
}
