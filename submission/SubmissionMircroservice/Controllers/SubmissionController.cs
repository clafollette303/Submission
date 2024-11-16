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
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Uploads", Path.GetRandomFileName());

            await using var writeStream = System.IO.File.Create(filePath);

            await 

            return Content("Hello");
        }
    }
}
