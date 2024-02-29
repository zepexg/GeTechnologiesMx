using Entity.Model;
using System.Linq.Expressions;

namespace Entity.Interface
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T Store(T entity);
        List<T> FindById(Expression<Func<T, bool>> Expression);
    }
}
