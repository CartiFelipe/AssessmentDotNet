using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assessment.Model;
using Assessment.Model.Context;

namespace Assessment.Pages.cruds.TouristPackage
{
    public class DeleteModel : PageModel
    {
        private readonly Assessment.Model.Context.TripContext _context;

        public DeleteModel(Assessment.Model.Context.TripContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Model.TouristPackage TouristPackage { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var touristpackage = await _context.TouristPackages.FirstOrDefaultAsync(m => m.Id == id);

            if (touristpackage is not null)
            {
                TouristPackage = touristpackage;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var touristpackage = await _context.TouristPackages.FindAsync(id);
            if (touristpackage != null)
            {
                TouristPackage = touristpackage;
                _context.TouristPackages.Remove(TouristPackage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
