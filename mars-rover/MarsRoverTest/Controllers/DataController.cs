using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NasaAPI.Services.Contracts;
using System.Threading.Tasks;

namespace MarsRoverTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;
        private readonly INasaApiService _nasaApiService;

        public DataController(ILogger<DataController> logger, INasaApiService nasaApiService)
        {
            _logger = logger;
            _nasaApiService = nasaApiService;
        }

        [HttpGet, Route("Process")]
        public async Task<IActionResult> Process()
        {
            await _nasaApiService.GetSaveRoverData();
            return Ok();
        }
    }
}
