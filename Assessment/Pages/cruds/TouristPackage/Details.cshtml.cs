using Assessment.Model;
using Assessment.Model.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Pages.cruds.TouristPackage
{
    public class DetailsModel : PageModel
    {
        private readonly TripContext _context;
        
        public List<City> Cities { get; set; } = default!;

        public DetailsModel(TripContext context)
        {
            _context = context;
        }

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
                Cities = _context.TouristPackages.Include(t => t.Cities).FirstOrDefault(t => t.Id == id)?.Cities
                    .ToList(); 

                return Page();
            }

            return NotFound();
        }
    }
}
