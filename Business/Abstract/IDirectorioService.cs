using Entity.Model;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IDirectorioService : IEntityService<PersonaModel>
    {
        List<PersonaModel> FindPersonas();
        void DeletePersonaByIdentificacion(string Identificacion);
    }
}
