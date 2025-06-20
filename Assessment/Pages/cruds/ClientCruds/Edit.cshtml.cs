using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assessment.Model;
using Assessment.Model.Context;

namespace Assessment.Pages.cruds.ClientCruds
{
    public class EditModel : PageModel
    {
        private readonly Assessment.Model.Context.TripContext _context;

        public EditModel(Assessment.Model.Context.TripContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client Client { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client =  await _context.Clients.Include(c => c.Reservations).FirstOrDefaultAsync(c => c.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            Client = client;

          
           
            return Page();
        }


        public IActionResult OnPost()
        {
            
            if (!ModelState.IsValid)
            {
                return        Page();        
                
            }
            
           
            _context.Attach(Client).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }

        
    }
}
