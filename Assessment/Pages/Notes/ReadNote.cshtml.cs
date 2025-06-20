using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assessment.Pages.Notes;

public class ReadNote : PageModel
{
    [BindProperty] public string Title { get; set; } = string.Empty;

    [BindProperty] public string Content { get; set; } = string.Empty;

    public void OnGet(string title)
    {
        Title = title;

        var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

        var filePath = Path.Combine(wwwrootPath, "notes", $"{Title}.txt");
        if (System.IO.File.Exists(filePath))
        {
            Content = System.IO.File.ReadAllText(filePath);
        }
        else
        {
            Title = "Nota não encontrada";
            Content = "A nota solicitada não existe.";
        }
    }
}