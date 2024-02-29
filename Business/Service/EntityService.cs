using Business.Abstract;
using Entity.Interface;
using Entity.Model;
using System.Linq.Expressions;

namespace Business.Service
{
    public class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IGenericRepository<T> _repository;

        public EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public virtual List<T> FindById(string Id)
        {
            return new List<T>();
        }

        public virtual List<T> FindById(Guid Id)
        {
            return new List<T>();
        }

        public virtual T Store(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var e = _repository.Store(entity);
            _unitOfWork.Save();
            return e;
        }
    }
}
