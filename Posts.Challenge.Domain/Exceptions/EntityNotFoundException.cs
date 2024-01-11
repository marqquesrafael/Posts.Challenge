namespace Posts.Challenge.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : base($"Não foi encontrado nenhum registro com os parametros informados.") { }
    }
}
