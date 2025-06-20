using Assessment.Model;
using Assessment.Model.Context;
using Assessment.Model.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Pages.cruds.ReservationCruds;

public class EditModel : PageModel
{
    private readonly TripContext _context;

    public EditModel(TripContext context, IReservationValidator validator)
    {
        Validator = validator;
        _context = context;
    }

    public IReservationValidator Validator { get; set; }

    [BindProperty] public Reservation Reservation { get; set; } = default!;

    public int ClientsRegistered { get; set; } = 0;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var reservation = await _context.Reservations.FirstOrDefaultAsync(m => m.Id == id);
        if (reservation == null) return NotFound();
        Reservation = reservation;


        ViewData["TouristPackageId"] = new SelectList(_context.TouristPackages, "Id", "Title");
        ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name");
        return Page();
    }


    public async Task<IActionResult> OnPost()
    {
        var erros = await Validator.ValidateAsync(Reservation);
        foreach (var error in erros) ModelState.AddModelError("", error);

        if (!ModelState.IsValid) return await OnGetAsync(Reservation.Id);

        _context.Attach(Reservation).State = EntityState.Modified;

        _context.SaveChanges();

        return RedirectToPage("./Index");
    }
}