using Microsoft.AspNetCore.Mvc;
using TheMonarchs.Services.Interfaces;

namespace TheMonarchsApi.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class MonarchController : ControllerBase
    {
        private readonly IFileService _fileService;
        public MonarchController(IFileService readFileService)
        {
            _fileService = readFileService;
        }

        [HttpGet("count")]
        public IActionResult MonarchCount()
        {
            var result = _fileService.GetMonarchesTotalNumber();
            return Ok(result);
        }

        [HttpGet("longestMonarchRuled")]
        public IActionResult LongestMonarchRuled()
        {
            var result = _fileService.LongestMonarchRuled();
            return Ok(result);
        }

        [HttpGet("longestHouseRuled")]
        public IActionResult LongestHouseRuled()
        {
            var result = _fileService.LongestHouseRuled();
            return Ok(result);
        }

        [HttpGet("mostcommonname")]
        public IActionResult MostCommonName()
        {
            var result = _fileService.MostCommonName();
            return Ok(result);
        }
    }
}
