using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SOA_CA2.contexts;
using SOA_CA2.models;

namespace SOA_CA2.Pages.InvoicePage
{
    public class IndexModel : PageModel
    {
        private readonly SOA_CA2.contexts.Customer_invoiceDB _context;

        public IndexModel(SOA_CA2.contexts.Customer_invoiceDB context)
        {
            _context = context;
        }

        public IList<Customer_invoice> Customer_invoice { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Customer_invoice != null)
            {
                Customer_invoice = await _context.Customer_invoice.ToListAsync();
            }
        }
    }
}
