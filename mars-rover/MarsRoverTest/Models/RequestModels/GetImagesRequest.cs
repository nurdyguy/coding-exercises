using System;

namespace MarsRoverTest.Models.RequestModels
{
    public class GetImagesRequest : PagedRequest
    {
        public DateTime Date { get; set; }
        public string RoverName { get; set; }
    }
}
