using Core.ExcelParser;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : Controller
    {
        private IExcelParser _parser;


        public UploadController(IExcelParser parser)
        {
            this._parser = parser;
        }

        [HttpGet]
        public IActionResult GetData()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostData([FromForm] IFormFile file)
        {
            using var stream = file.OpenReadStream();
            var data = _parser.Parse(stream);

            return Ok(data);
        }
    }
}
