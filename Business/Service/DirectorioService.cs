using Business.Abstract;
using Entity.Interface;
using Entity.Model;
using System.Linq.Expressions;

namespace Business.Service
{
    public class DirectorioService : EntityService<PersonaModel>, IDirectorioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonaRepository _repository;

        public DirectorioService(IUnitOfWork unitOfWork, IPersonaRepository repository):base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void DeletePersonaByIdentificacion(string Identificacion)
        {
            Expression<Func<PersonaModel, bool>> param = entity => entity.Identificacion == Identificacion;
            _repository.DeletePersonaByIdentificacion(param);
            _unitOfWork.Save();
        }

        public List<PersonaModel> FindPersonas()
        {
            return _repository.FindPersonas();
        }
        public override List<PersonaModel> FindById(string Id)
        {
            Expression<Func<PersonaModel, bool>> param = entity => entity.Identificacion == Id;
            return _repository.FindById(param);
        }
    }
}
