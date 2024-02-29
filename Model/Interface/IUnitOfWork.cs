namespace Entity.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();
    }
}
