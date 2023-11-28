using Microsoft.EntityFrameworkCore;
using SOA_CA2.models;

namespace SOA_CA2.contexts
{
    public class CustomerDB : DbContext
    {
        public CustomerDB(DbContextOptions<CustomerDB> options)
        : base(options) { }

        public DbSet<Customer> Customer => Set<Customer>();
    }
}
