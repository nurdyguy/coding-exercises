using AutoMapper;
using MarsRoverTest.Models;
using MarsRoverTest.Models.RequestModels;
using MarsRoverTest.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NasaAPI.Models.RequestModels;
using NasaAPI.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRoverTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoverImageController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;
        private readonly INasaApiService _nasaApiService;
        private readonly IMapper _mapper;

        public RoverImageController(ILogger<DataController> logger, INasaApiService nasaApiService, IMapper mapper)
        {
            _logger = logger;
            _nasaApiService = nasaApiService;
            _mapper = mapper;
        }

        [HttpGet, Route("FilterOptions")]
        public async Task<IActionResult> GetFilterOptions()
        {
            var opts = _nasaApiService.GetSearchOptions();
            var result = new FilterOptionsResponse()
            {
                Dates = opts.Dates,
                Rovers = opts.Rovers
            };
            return new JsonResult(result);
        }

        [HttpGet, Route("{id:int}")]
        public async Task<IActionResult> GetImage(int id)
        {
            var image = _nasaApiService.GetImage(id);
            var resp = _mapper.Map<RoverImage>(image);
            return new JsonResult(resp);
        }

        [HttpPost, Route("Search")]
        public async Task<IActionResult> Search([FromBody]GetImagesRequest request)
        {
            var images = _nasaApiService.SearchImages(new SearchImagesRequest()
            {
                Dates = request.Dates,
                RoverNames = request.RoverNames,
                Page = request.Page,
                PerPage = request.PerPage
            });
            var response = new GetImagesResponse()
            {
                RoverImages = _mapper.Map<IEnumerable<RoverImage>>(images.RoverImages),
                Page = images.Page,
                PerPage = images.PerPage,
                Total = images.Total
            };
            return new JsonResult(response);
        }
    }
}
