namespace Data.Context
{
    public static class DbInitializer
    {
        public static void Inizialize(AppDbContext context)
        {
            try
            {
                context.Database.EnsureCreated();

                if (context.Persona.Any() || context.Factura.Any())
                {
                    return;
                }

                context.SaveChanges();
            }catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }
        }
    }
}
