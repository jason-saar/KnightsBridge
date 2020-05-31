using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using KnightsBridge.Data;
using KnightsBridge.Models;
using System;

namespace KnightsBridge.Hubs
{
    public class ChatHub : Hub
    {
        private readonly KnightsBridgeContext _context;

        public ChatHub(KnightsBridgeContext context)
        {
            _context = context;
        }

        public async Task SendMessage(string user, string message)
        {
            var temp = new ChatMsg
            {
                User = user,
                Message = message,
                Posted = DateTime.Now
            };
            _context.Messages.Add(temp);
            await _context.SaveChangesAsync();
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}