namespace SOA_CA2.models
{
    using Microsoft.EntityFrameworkCore;
    public class CustomerDB : DbContext
    {
        public CustomerDB(DbContextOptions<CustomerDB> options)
        : base(options) { }

        public DbSet<Customer> Customer => Set<Customer>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                _ = optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING"));
            }
        }
    }
}
