using Business.Abstract;
using Entity.Interface;
using Entity.Model;
using System.Linq.Expressions;

namespace Business.Service
{
    public class VentaService : EntityService<FacturaModel>, IVentaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFacturaRepository _repository;

        public VentaService(IUnitOfWork unitOfWork, IFacturaRepository repository) : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public override List<FacturaModel> FindById(Guid Id)
        {
            Expression<Func<FacturaModel, bool>> param = entity => entity.PersonaId == Id;
            return _repository.FindById(param);
        }
    }
}
