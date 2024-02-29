using Entity.Model;

namespace Business.Abstract
{
    public interface IEntityService<T> : IService where T : BaseEntity
    {
        T Store(T entity);
        List<T> FindById(string Id);
        List<T> FindById(Guid Id);
    }
}
