using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GridController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetData()
        {
            var dataSample = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"column1", "value 1-1"},
                    {"column2", "value 1-2"}
                },
                new Dictionary<string, string>
                {
                    {"column1", "value 2-1"},
                    {"column2", "value 2-2"}
                }
            };
            return Ok(dataSample);
        }

        [HttpPost]
        public async Task<IActionResult> PostData([FromForm] IFormFile file)
        {
            Console.WriteLine("got file: " + file.FileName);

            return Ok();
        }
    }
}
