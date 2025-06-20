using Assessment.Model;
using Assessment.Model.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Pages.cruds.ReservationCruds;

public class DeleteModel : PageModel
{
    private readonly TripContext _context;

    public DeleteModel(TripContext context)
    {
        _context = context;
    }

    [BindProperty] public Reservation Reservation { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var reservation =
            await _context.Reservations.Include(r => r.TouristPackage).FirstOrDefaultAsync(m => m.Id == id);

        if (reservation is not null)
        {
            Reservation = reservation;

            return Page();
        }

        return NotFound();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null) return NotFound();

        var reservation = await _context.Reservations.FindAsync(id);
        if (reservation != null)
        {
            Reservation = reservation;
            _context.Reservations.Remove(Reservation);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}