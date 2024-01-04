using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class GridController : ControllerBase
    {
        [HttpGet]
        public string GetData()
        {
            return "GetData controller works!";
        }
    }
}
