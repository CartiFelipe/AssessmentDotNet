using Assessment.Model.Context;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Pages.cruds.TouristPackage
{
    public class IndexModel : PageModel
    {
        private readonly TripContext _context;

        public IndexModel(TripContext context)
        {
            _context = context;
        }

        public IList<Model.TouristPackage> TouristPackage { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TouristPackage = await _context.TouristPackages.ToListAsync();
        }
    }
}
