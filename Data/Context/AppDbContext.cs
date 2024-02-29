using Data.Abstract;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public  DbSet<PersonaModel> Persona { get; set; }
        public  DbSet<FacturaModel> Factura { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            try
            {
                builder.Entity<PersonaModel>().ToTable("Persona")
                    .HasMany(p => p.Facturas)
                    .WithOne(p => p.Persona)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasForeignKey(p => p.PersonaId)
                    .HasPrincipalKey(p => p.Id);

            }catch (Exception ex)
            {
                throw new Exception("Error: Problema con DB", ex);
            }
        }

    }
}
