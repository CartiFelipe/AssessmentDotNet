using Assessment.Model;
using Assessment.Model.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Pages.cruds.ClientCruds
{
    public class DetailsModel : PageModel
    {
        private readonly TripContext _context;

        public DetailsModel(TripContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client? Client { get; set; } = default!;
        
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public void OnGet(int? id)
        {
           
            Client = _context.Clients.Include(c => c.Reservations)
                .FirstOrDefault(c => c.Id == id);



        }
    }
}
