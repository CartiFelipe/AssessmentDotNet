using Assessment.Model.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assessment.Pages.cruds.TouristPackage;

public class CreateModel : PageModel
{
    private readonly TripContext _context;

    public CreateModel(TripContext context)
    {
        _context = context;
    }

    [BindProperty] public Model.TouristPackage TouristPackage { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ModelState.Remove("TouristPackage.InitialDate");
            ModelState.AddModelError("TouristPackage.InitialDate", "A data não pode ser nula ou inválida!");

            return Page();
        }

        _context.TouristPackages.Add(TouristPackage);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}