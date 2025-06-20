using System.ComponentModel.DataAnnotations;
using Assessment.Model;
using Assessment.Model.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Pages.cruds.TouristPackage;

public class AddCity : PageModel
{
    private readonly TripContext _context;


    public AddCity(TripContext context)
    {
        _context = context;
    }

    [BindProperty] public List<City> Cities { get; set; }

    [BindProperty] public int Id { get; set; }

    [BindProperty]
    [Display(Name = "Cidade: ")]
    [Required(ErrorMessage = "Cidade é obrigatória")]

    public int CityId { get; set; }

    public void OnGet(int id)
    {
        Id = id;
        Cities = _context.Cities.ToList();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();


        var city = _context.Cities.FirstOrDefault(c => c.Id == CityId);
        _context.TouristPackages.Include(t => t.Cities).FirstOrDefault(t => t.Id == Id).Cities.Add(city);

        _context.SaveChanges();

        return RedirectToPage("./Details", new { id = Id });
    }
}