using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SOA_CA2.contexts;
using SOA_CA2.models;

namespace SOA_CA2.Pages.InvoicePage
{
    public class EditModel : PageModel
    {
        private readonly SOA_CA2.contexts.Customer_invoiceDB _context;

        public EditModel(SOA_CA2.contexts.Customer_invoiceDB context)
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

            var customer_invoice =  await _context.Customer_invoice.FirstOrDefaultAsync(m => m.customer_invoice_id == id);
            if (customer_invoice == null)
            {
                return NotFound();
            }
            Customer_invoice = customer_invoice;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Customer_invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Customer_invoiceExists(Customer_invoice.customer_invoice_id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Customer_invoiceExists(int id)
        {
          return (_context.Customer_invoice?.Any(e => e.customer_invoice_id == id)).GetValueOrDefault();
        }
    }
}
