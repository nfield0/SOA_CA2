using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SOA_CA2.contexts;
using SOA_CA2.models;

namespace SOA_CA2.Pages.CustomerPage
{
    public class IndexModel : PageModel
    {
        private readonly SOA_CA2.models.CustomerDB _context;

        public IndexModel(SOA_CA2.models.CustomerDB context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Customer != null)
            {
                Customer = await _context.Customer.ToListAsync();
            }
        }
    }
}
