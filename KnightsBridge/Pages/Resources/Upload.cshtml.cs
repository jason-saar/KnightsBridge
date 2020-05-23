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

namespace KnightsBridge.Pages.Resources
{
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
            var file = Path.Combine(_hostEnvironment.WebRootPath, "App_data", Upload.FileName);
            Directory.CreateDirectory(Path.Combine(_hostEnvironment.WebRootPath, "App_data"));
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);
            }
        }
    }
}