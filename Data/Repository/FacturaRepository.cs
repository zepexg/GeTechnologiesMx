using Data.Abstract;
using Entity.Interface;
using Entity.Model;

namespace Data.Repository
{
    public class FacturaRepository : GenericRepository<FacturaModel>, IFacturaRepository
    {
        public FacturaRepository(IAppDbContext context) : base(context) { }
    }
}
