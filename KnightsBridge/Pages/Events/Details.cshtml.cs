using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KnightsBridge.Data;
using KnightsBridge.Models;

namespace KnightsBridge.Pages.Events.Events
{
    public class DetailsModel : PageModel
    {
        private readonly KnightsBridge.Data.KnightsBridgeContext _context;

        public DetailsModel(KnightsBridge.Data.KnightsBridgeContext context)
        {
            _context = context;
        }

        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events.FirstOrDefaultAsync(m => m.EventId == id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
