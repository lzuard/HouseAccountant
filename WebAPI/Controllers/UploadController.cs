using Core.DataWorker;
using Core.ExcelParser;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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


        /// <summary>
        /// Get file and return preview
        /// </summary>
        /// <param name="file">Excel file</param>
        /// <returns>Json with paresd file</returns>
        [HttpPost]
        public async Task<IActionResult> PostData([FromForm] IEnumerable<IFormFile> files)
        {
            if (!files.Any())
                return BadRequest();

            var streamsList = new List<Stream>();
            foreach (var file in files)
            {
                streamsList.Add(file.OpenReadStream());
            }
            var (header, parsedData) = await _parser.ParseNewAsync(streamsList);
            var result = new
            {
                header = header,
                data = parsedData
            };
            var json = JsonConvert.SerializeObject(result, Formatting.Indented);

            return Ok(json);
        }
    }
}
