using Data.Abstract;
using Entity.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly IAppDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(IAppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public List<T> FindById(Expression<Func<T, bool>> Expression)
        {
            return _dbSet.Where(Expression).ToList();
        }

        public virtual T Store(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }
    }
}
