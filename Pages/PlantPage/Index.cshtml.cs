using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SOA_CA2.models;

namespace SOA_CA2.Pages.PlantPage
{
    public class IndexModel : PageModel
    {
        private readonly SOA_CA2.models.PlantDB _context;

        public IndexModel(SOA_CA2.models.PlantDB context)
        {
            _context = context;
        }

        public IList<Plant> Plant { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Plant != null)
            {
                Plant = await _context.Plant.ToListAsync();
            }
        }
    }
}
