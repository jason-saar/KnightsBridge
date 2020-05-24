using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KnightsBridge.Pages.Resources
{
    public class IndexModel : PageModel
    {
        private IWebHostEnvironment _hostEnvironment;
        public IList<FileInfo> Uploads { get; set; }

        public IndexModel (IWebHostEnvironment environment)
        {
            _hostEnvironment = environment;
        }

        public void OnGet()
        {
            string currentDir = _hostEnvironment.WebRootPath;
            string uploadDir = Path.Combine(currentDir, "Downloads");
            try
            {
                var files = Directory.EnumerateFiles(uploadDir).ToList();
                List<FileInfo> tempList = new List<FileInfo>();
                foreach (string file in files)
                {
                    var fileInfo = new FileInfo(file);
                    
                    tempList.Add(fileInfo);
                }
                Uploads = tempList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}