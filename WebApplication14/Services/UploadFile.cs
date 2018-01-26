using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WebApplication14.Services
{
    public class UploadFile
    {
        public async Task<String> AddFile(byte[] fileContent, string FileName, string ContentType, IHostingEnvironment environment)
        {

            string path = $@"{FileName}";
            using (FileStream fstream = new FileStream(environment.WebRootPath + path, FileMode.OpenOrCreate))
            {
                await fstream.WriteAsync(fileContent, 0, fileContent.Length);

            }
            string base64path = "data:image / gif;base64,"+Convert.ToBase64String(fileContent);
            return base64path;
        }
    }
}
