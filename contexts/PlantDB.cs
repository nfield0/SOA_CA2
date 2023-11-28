namespace SOA_CA2.models
{
    using Microsoft.EntityFrameworkCore;

    public class PlantDB : DbContext
    {
        public PlantDB(DbContextOptions<PlantDB> options)
        : base(options) { }

        public DbSet<Plant> Plant => Set<Plant>();
    }
}
