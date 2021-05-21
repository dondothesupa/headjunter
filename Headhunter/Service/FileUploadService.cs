﻿using System.IO;
using Microsoft.AspNetCore.Http;

namespace Headhunter.Service
{
    public class FileUploadService
    {
        public async void Upload(string path, string filename, IFormFile file)
        {
            using var stream = new FileStream(Path.Combine(path, filename), FileMode.Create);
            await file.CopyToAsync(stream);
        }
    }
}