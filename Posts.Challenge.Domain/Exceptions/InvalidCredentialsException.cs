namespace Posts.Challenge.Domain.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException() : base($"Falha no login, credenciais inválidas")
        {

        }
    }
}
