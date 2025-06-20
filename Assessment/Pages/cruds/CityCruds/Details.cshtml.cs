using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assessment.Model;
using Assessment.Model.Context;

namespace Assessment.Pages.cruds.CityCruds
{
    public class DetailsModel : PageModel
    {
        private readonly Assessment.Model.Context.TripContext _context;

        public DetailsModel(Assessment.Model.Context.TripContext context)
        {
            _context = context;
        }

        public City City { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.Cities.FirstOrDefaultAsync(m => m.Id == id);

            if (city is not null)
            {
                City = city;

                return Page();
            }

            return NotFound();
        }
    }
}
