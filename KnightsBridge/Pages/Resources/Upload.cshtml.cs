using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace KnightsBridge.Pages.Resources
{
    [Authorize(Roles = "Admin")]
    public class UploadModel : PageModel
    {
        private IWebHostEnvironment _hostEnvironment;
        public string FileName { get; set; }
        
        public UploadModel(IWebHostEnvironment environment)
        {
            _hostEnvironment = environment;
            FileName = "Not Available";
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public IFormFile Upload { get; set; }
        public async Task OnPostAsync()
        {
            string currentDir = _hostEnvironment.WebRootPath;
            var file = Path.Combine(currentDir, "Downloads", Upload.FileName);
            file = file.Replace(" ", "_");
            Directory.CreateDirectory(Path.Combine(currentDir, "Downloads"));
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);
            }
        }
    }
}