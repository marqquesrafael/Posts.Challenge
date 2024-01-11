namespace Posts.Challenge.Domain.Exceptions
{
    public class InsertEntityWithIdException : Exception
    {
        public InsertEntityWithIdException() : base("Erro ao inserir registro, Não é possível inserir um registro com Id pré definido") { }
    }
}
