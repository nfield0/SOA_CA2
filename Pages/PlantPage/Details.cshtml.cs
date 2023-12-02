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
    public class DetailsModel : PageModel
    {
        private readonly SOA_CA2.models.PlantDB _context;

        public DetailsModel(SOA_CA2.models.PlantDB context)
        {
            _context = context;
        }

      public Plant Plant { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Plant == null)
            {
                return NotFound();
            }

            var plant = await _context.Plant.FirstOrDefaultAsync(m => m.plant_id == id);
            if (plant == null)
            {
                return NotFound();
            }
            else 
            {
                Plant = plant;
            }
            return Page();
        }
    }
}
