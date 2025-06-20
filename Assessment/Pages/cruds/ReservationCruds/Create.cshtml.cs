using Assessment.Model;
using Assessment.Model.Context;
using Assessment.Model.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assessment.Pages.cruds.ReservationCruds;

public class CreateModel : PageModel
{
    public readonly TripContext _context;


    public CreateModel(TripContext context, IReservationValidator validator)
    {
        Validator = validator;

        _context = context;
    }

    public IReservationValidator Validator { get; set; }

    [BindProperty] public Reservation Reservation { get; set; } = default!;

    public IActionResult OnGet()
    {
        ViewData["TouristPackageId"] = new SelectList(_context.TouristPackages, "Id", "Title");
        ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name");
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var errors = await Validator.ValidateAsync(Reservation);

        foreach (var error in errors) ModelState.AddModelError("", error);

        if (!ModelState.IsValid)
        {
            ModelState.Remove("Reservation.ReservationDate");
            return OnGet();
        }

        await _context.Reservations.AddAsync(Reservation);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}