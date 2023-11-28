using Microsoft.EntityFrameworkCore;
using SOA_CA2.models;

namespace SOA_CA2.contexts
{
    public class Customer_invoiceDB : DbContext
    {
        public Customer_invoiceDB(DbContextOptions<Customer_invoiceDB> options)
        : base(options) { }

        public DbSet<Customer_invoice> Customer_invoice =>  Set<Customer_invoice>();
    }
}
