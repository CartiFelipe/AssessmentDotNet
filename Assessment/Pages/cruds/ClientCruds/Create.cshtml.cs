using Assessment.Model;
using Assessment.Model.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assessment.Pages.cruds.ClientCruds;

public class CreateModel : PageModel
{
    private readonly TripContext _context;

    public CreateModel(TripContext context)
    {
        _context = context;
    }

    [BindProperty] public Client Client { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public IActionResult OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            _context.Clients.Add(Client);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }

        return Page();
    }
}