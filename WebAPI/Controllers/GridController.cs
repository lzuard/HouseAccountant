﻿using Core.ExcelParser;
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
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostData([FromForm] IFormFile file)
        {

            return Ok();
        }
    }
}
