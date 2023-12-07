namespace SOA_CA2.models
{
    using Microsoft.EntityFrameworkCore;
    public class CustomerDB : DbContext
    {
        public CustomerDB(DbContextOptions<CustomerDB> options)
        : base(options) { }

        public DbSet<Customer> Customer => Set<Customer>();
    }
}
