using Microsoft.EntityFrameworkCore;

namespace Data.Abstract
{
    public interface IAppDbContext
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
    }
}
