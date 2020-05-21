using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KnightsBridge.Models;
using System.Text.Json;

namespace KnightsBridge.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly KnightsBridge.Data.KnightsBridgeContext _context;

        public IndexModel(KnightsBridge.Data.KnightsBridgeContext context)
        {
            _context = context;
        }

        public IActionResult OnGetFindAllEvents()
        {
            var events = _context.Events.Select(x => new
            {
                id = x.EventId,
                title = x.Title,
                description = x.Description,
                start = x.Start,
                end = x.End,
                allDay = false
            }).ToList();
            return new JsonResult(events);
        }

        public IList<Event> Event { get;set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Events.ToListAsync();
        }
    }
}
