using System;
using System.Collections.Generic;

namespace NasaAPI.Models.ResponseModels
{
    public class SearchOptionsResponse
    {
        public IEnumerable<DateTime> Dates { get; set; }
        public IEnumerable<string> Rovers { get; set; }
    }
}
