using Entity.Model;
using System.Linq.Expressions;

namespace Entity.Interface
{
    public interface IPersonaRepository : IGenericRepository<PersonaModel>
    {
        public List<PersonaModel> FindPersonas();
        public void DeletePersonaByIdentificacion(Expression<Func<PersonaModel, bool>> Expression);
    }
}
