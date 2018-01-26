using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using WebApplication14.Services;

namespace WebApplication14.Controllers
{
    [Produces("application/json")]
    [Route("api/Upload")]
    public class UploadController : Controller
    {
        private readonly UploadFile _uploadService;
        private readonly IHostingEnvironment _environment;
        public UploadController(IHostingEnvironment environment)
        {
            _uploadService = new UploadFile();
            _environment = environment;
        }

        [HttpPost]
        [Route("/api/upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null) throw new Exception("File is null");
            if (file.Length == 0) throw new Exception("File is empty");

            using (Stream stream = file.OpenReadStream())
            {
                using (var binaryReader = new BinaryReader(stream))
                {
                    var fileContent = binaryReader.ReadBytes((int)file.Length);
                    string path = await _uploadService.AddFile(fileContent, file.FileName, file.ContentType, _environment);

                    return Ok(path);
                }
            }
           
        }
    }
}
  