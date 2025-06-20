using Assessment.Model.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Pages.cruds.TouristPackage;

public class EditModel : PageModel
{
    private readonly TripContext _context;

    public EditModel(TripContext context)
    {
        _context = context;
    }

    [BindProperty] public Model.TouristPackage TouristPackage { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var touristpackage = await _context.TouristPackages.Include(t => t.Cities).FirstOrDefaultAsync(m => m.Id == id);
        if (touristpackage == null) return NotFound();
        TouristPackage = touristpackage;
        return Page();
    }


    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid) return await OnGetAsync(TouristPackage.Id);

        _context.Attach(TouristPackage).State = EntityState.Modified;
        _context.SaveChanges();


        return RedirectToPage("./Index");
    }

    public void OnPostAdd()
    {
        Console.WriteLine("Fui clicado");
    }
}