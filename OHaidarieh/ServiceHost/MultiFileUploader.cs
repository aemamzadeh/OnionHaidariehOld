using _0_Framework.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost
{
    public class MultiFileUploader 
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MultiFileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Upload(List<IFormFile> files, string path)
        {
            if (files == null && files.Count == 0) return null;
            var directoryPath = $"{ _webHostEnvironment.WebRootPath}//{path}";
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            //var fileNames = new List<string>();
            string fileName;

            foreach (IFormFile item in files)
            {
                if (item.Length > 0)
                {
                    fileName = $"{DateTime.Now.ToFileName()}-{item.FileName}";
                    //fileNames.Add(fileName);

                    var filePath = $"{directoryPath}//{fileName}";
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }
                }
                
            }
            return null;// $"{path}/{fileName}";
        }
    }
}
