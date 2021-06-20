using System;
using System.Collections.Generic;

namespace NasaAPI.Models.RequestModels
{
    public class SearchImagesRequest : PagedRequest
    {
        public IEnumerable<DateTime> Dates { get; set; }
        public IEnumerable<string> RoverNames { get; set; }
    }
}
