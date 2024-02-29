using Data.Abstract;
using Entity.Interface;
using Entity.Model;
using System.Linq.Expressions;

namespace Data.Repository
{
    public class PersonaRepository : GenericRepository<PersonaModel>, IPersonaRepository
    {
        public PersonaRepository(IAppDbContext context): base(context) { }
        public void DeletePersonaByIdentificacion(Expression<Func<PersonaModel, bool>> Expression)
        {
            var persona = _dbSet.Where(Expression).FirstOrDefault();
            if (persona != null)
            {
                var facturas = _context.Set<FacturaModel>().Where(o => o.PersonaId == persona.Id);
                _context.Set<FacturaModel>().RemoveRange(facturas);
                _dbSet.Remove(persona);
            }
        }

        public List<PersonaModel> FindPersonas()
        {
            return _dbSet.ToList();
        }
    }
}
