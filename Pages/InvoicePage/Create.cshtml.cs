using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SOA_CA2.contexts;
using SOA_CA2.models;

namespace SOA_CA2.Pages.InvoicePage
{
    public class CreateModel : PageModel
    {
        private readonly SOA_CA2.contexts.Customer_invoiceDB _context;

        public CreateModel(SOA_CA2.contexts.Customer_invoiceDB context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer_invoice Customer_invoice { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Customer_invoice == null || Customer_invoice == null)
            {
                return Page();
            }

            _context.Customer_invoice.Add(Customer_invoice);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
