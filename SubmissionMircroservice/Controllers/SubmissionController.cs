using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Web;
using System.Net.Http;

namespace SubmissionMircroservice.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var filePath = CreateFilePath();

            await using var writeStream = System.IO.File.Create(filePath);

            foreach (var file in Request.Form.Files)
            {
                await file.CopyToAsync(writeStream);
            }

            return Ok();
        }

        private string CreateFilePath()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            var path = Path.Combine(Directory.GetCurrentDirectory(), @"Uploads", finalString);
            path += ".js";

            return $"{path}";
        }
    }
}
