using Core.DataWorker;
using Core.ExcelParser;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : Controller
    {
        private IExcelParser _parser;
        private IDataWorker _dataWorker;


        public UploadController(IExcelParser parser, IDataWorker dataWorker)
        {
            _parser = parser;
            _dataWorker = dataWorker;
        }

        [HttpGet]
        public async Task<IActionResult> GetData([FromBody] IEnumerable<Dictionary<string, string>> data)
        {
            await _dataWorker.SaveDataAsync(data);
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
