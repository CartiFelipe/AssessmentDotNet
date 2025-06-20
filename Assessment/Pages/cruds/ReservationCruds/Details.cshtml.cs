using Assessment.Model;
using Assessment.Model.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Pages.cruds.ReservationCruds;

public class DetailsModel : PageModel
{
    private readonly TripContext _context;

    public DetailsModel(TripContext context)
    {
        _context = context;
    }

    [BindProperty] public Model.TouristPackage? TouristPackage { get; set; }

    public Reservation Reservation { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var reservation = await _context.Reservations.FirstOrDefaultAsync(m => m.Id == id);

        if (reservation is not null)
        {
            Reservation = reservation;
            TouristPackage = await _context.TouristPackages
                .Include(t => t.Cities)
                .FirstOrDefaultAsync(t => t.Id == reservation.TouristPackageId)!;

            return Page();
        }

        return NotFound();
    }
}