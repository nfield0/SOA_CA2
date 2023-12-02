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
    public class DeleteModel : PageModel
    {
        private readonly SOA_CA2.contexts.Customer_invoiceDB _context;

        public DeleteModel(SOA_CA2.contexts.Customer_invoiceDB context)
        {
            _context = context;
        }

        [BindProperty]
      public Customer_invoice Customer_invoice { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Customer_invoice == null)
            {
                return NotFound();
            }

            var customer_invoice = await _context.Customer_invoice.FirstOrDefaultAsync(m => m.customer_id == id);

            if (customer_invoice == null)
            {
                return NotFound();
            }
            else 
            {
                Customer_invoice = customer_invoice;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Customer_invoice == null)
            {
                return NotFound();
            }
            var customer_invoice = await _context.Customer_invoice.FindAsync(id);

            if (customer_invoice != null)
            {
                Customer_invoice = customer_invoice;
                _context.Customer_invoice.Remove(Customer_invoice);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
