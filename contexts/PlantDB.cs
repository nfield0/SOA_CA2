namespace SOA_CA2.models
{
    using Microsoft.EntityFrameworkCore;

    public class PlantDB : DbContext
    {
        public PlantDB(DbContextOptions<PlantDB> options)
        : base(options) { }

        public DbSet<Plant> Plant => Set<Plant>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                _ = optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING"));
            }
        }
    }
}
