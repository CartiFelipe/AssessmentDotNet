using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assessment.Model;
using Assessment.Model.Context;

namespace Assessment.Pages.cruds.ClientCruds
{
    public class IndexModel : PageModel
    {
        private readonly Assessment.Model.Context.TripContext _context;

        public IndexModel(Assessment.Model.Context.TripContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Client = await _context.Clients.ToListAsync();
        }
    }
}
