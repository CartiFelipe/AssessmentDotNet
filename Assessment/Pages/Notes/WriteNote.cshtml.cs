using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assessment.Pages.Notes;

public class WriteNote : PageModel
{
    [BindProperty] public Note Note { get; set; } = new();
    [BindProperty] public List<string> Notes { get; set; } = new();


    public void OnGet()
    {
        var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        var notesPath = Path.Combine(wwwrootPath, "notes");
        if (!Directory.Exists(notesPath)) Directory.CreateDirectory(notesPath);
        var noteFiles = Directory.GetFiles(notesPath, "*.txt");
        foreach (var noteFile in noteFiles)
        {
            var fileName = Path.GetFileNameWithoutExtension(noteFile);
            if (fileName != null) Notes.Add(fileName);
        }
    }


    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();


        var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

        System.IO.File.WriteAllText($"{wwwrootPath}/notes/{Note.Title}.txt", Note.Content);


        return RedirectToPage("./ReadNote", new { title = Note.Title });
    }
}

public class Note
{
    [Required(ErrorMessage = "O título é obrigatório")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "O conteúdo é obrigatório")]
    public string Content { get; set; } = string.Empty;
}