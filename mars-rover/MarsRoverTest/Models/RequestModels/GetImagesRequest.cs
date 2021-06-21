using System;
using System.Collections.Generic;

namespace MarsRoverTest.Models.RequestModels
{
    public class GetImagesRequest : PagedRequest
    {
        public IEnumerable<DateTime> Dates { get; set; }
        public IEnumerable<string> RoverNames { get; set; }
    }
}
