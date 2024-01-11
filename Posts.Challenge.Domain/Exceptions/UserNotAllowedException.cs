namespace Posts.Challenge.Domain.Exceptions
{
    public class UserNotAllowedException : Exception
    {
        public UserNotAllowedException() : base("O post solicitado não pertence ao usuário logado!")
        {

        }
    }
}
