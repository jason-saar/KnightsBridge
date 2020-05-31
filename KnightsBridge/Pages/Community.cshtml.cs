using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnightsBridge.Data;
using KnightsBridge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KnightsBridge.Pages
{
    public class CommunityModel : PageModel
    {
        private readonly KnightsBridgeContext _context;
        public IList<ChatMsg> Messages { get; set; }

        public CommunityModel(KnightsBridgeContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Messages = await _context.Messages.ToListAsync();
        }
    }
}