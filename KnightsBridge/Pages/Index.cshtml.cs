using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using KnightsBridge.Data;
using KnightsBridge.Models;
using Microsoft.EntityFrameworkCore;

namespace KnightsBridge.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly KnightsBridgeContext _context;
        private readonly ILogger<IndexModel> _logger;
        public IList<Event> Event { get; set; }

        public IndexModel(ILogger<IndexModel> logger, KnightsBridgeContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            List<Event> tempEvents = await _context.Events.ToListAsync();
            List<Event> events = new List<Event>();
            foreach (var e in tempEvents)
            {
                if(e.Start < DateTime.Now.AddMonths(1))
                {
                    events.Add(e);
                }
            }
            Event = events;
        }


    }
}
