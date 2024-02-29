using Data.Abstract;
using Entity.Interface;
using Microsoft.EntityFrameworkCore;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IAppDbContext _dbContext;

        public UnitOfWork(IAppDbContext context)
        {
            _dbContext = context;
        }
        public void Dispose()
        {
            Dispose(true);
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }
        private void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                ((DbContext)_dbContext).Dispose();
                _dbContext = null;
            }
        }
    }
}
