using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GridController : ControllerBase
    {
        [HttpGet]
        public string GetData()
        {
            return "GetData controller works!";
        }
    }
}
