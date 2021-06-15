using MarsRoverTest.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NasaAPI.Models.RequestModels;
using NasaAPI.Services.Contracts;
using System.Threading.Tasks;

namespace MarsRoverTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoverImageController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;
        private readonly INasaApiService _nasaApiService;

        public RoverImageController(ILogger<DataController> logger, INasaApiService nasaApiService)
        {
            _logger = logger;
            _nasaApiService = nasaApiService;

        }

        [HttpGet, Route("{id:int}")]
        public async Task<IActionResult> GetImage(int id)
        {
            var image = _nasaApiService.GetImage(id);
            return new JsonResult(image);
        }

        [HttpPost, Route("Search")]
        public async Task<IActionResult> Search([FromBody]GetImagesRequest request)
        {
            var images = _nasaApiService.SearchImages(new SearchImagesRequest()
            {
                Date = request.Date,
                RoverName = request.RoverName,
                Page = request.Page,
                PerPage = request.PerPage
            });
            return new JsonResult(images);
        }
    }
}
