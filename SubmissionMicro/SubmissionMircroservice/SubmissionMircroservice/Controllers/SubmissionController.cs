using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

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
            var filePath = CreateFilePath(".js");

            await using var writeStream = System.IO.File.Create(filePath);

            foreach (var file in Request.Form.Files)
            {
                await file.CopyToAsync(writeStream);
            }

            return Ok();
        }

        /// <summary>
        /// Creates a randomly generated file name to store in 'Uploads' with the given extension
        /// </summary>
        /// <param name="extension">The extension to append to filepath</param>
        /// <returns></returns>
        private string CreateFilePath(string extension)
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
            path += extension;

            return $"{path}";
        }
    }
}
