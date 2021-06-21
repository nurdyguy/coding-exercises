using System;
using System.Collections.Generic;

namespace MarsRoverTest.Models.ResponseModels
{
    public class FilterOptionsResponse
    {
        public IEnumerable<DateTime> Dates { get; set; }
        public IEnumerable<string> Rovers { get; set; }
    }
}
