using Assessment.Model;
using Assessment.Model.Context;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Pages.cruds.ReservationCruds;

public class IndexModel : PageModel
{
    private readonly TripContext _context;

    public IndexModel(TripContext context)
    {
        _context = context;
    }

    public IList<Reservation> Reservation { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Reservation = await _context.Reservations
            .Include(r => r.TouristPackage).Include(r => r.Client).ToListAsync();
    }
}