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
    public class IndexModel : PageModel
    {
        private readonly KnightsBridge.Data.KnightsBridgeContext _context;

        public IndexModel(KnightsBridge.Data.KnightsBridgeContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Events.ToListAsync();
        }
    }
}
