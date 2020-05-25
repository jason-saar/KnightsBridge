using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KnightsBridge.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KnightsBridge.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "Admin")]
    public class AdminPanelModel : PageModel
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<KnightsBridgeUser> _userManager;
        public string FileName { get; set; }
        public string UserName { get; set; }
        public IList<string> Roles { get; set; }
        public List<KnightsBridgeUser> Users { get; set; }

        public AdminPanelModel(IWebHostEnvironment environment, UserManager<KnightsBridgeUser> userManager)
        {
            _hostEnvironment = environment;
            _userManager = userManager;
            FileName = "Not Available";
        }

        private async Task LoadAsync(KnightsBridgeUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var userName = await _userManager.GetUserNameAsync(user);

            Roles = roles;
            UserName = userName;
            Users = await GetUsersAsync();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<List<KnightsBridgeUser>> GetUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        [BindProperty]
        public IFormFile Upload { get; set; }
        public async Task OnPostAsync()
        {
            string currentDir = _hostEnvironment.WebRootPath;
            var file = Path.Combine(currentDir, "Downloads", Upload.FileName);
            FileName = Upload.FileName;
            file = file.Replace(" ", "_");
            Directory.CreateDirectory(Path.Combine(currentDir, "Downloads"));
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);
            }
        }
    }
}
