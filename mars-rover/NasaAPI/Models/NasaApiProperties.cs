using System;
using System.Collections.Generic;
using System.Text;

namespace NasaAPI.Models
{
    public class NasaApiProperties
    {
        public string ApiKey { get; set; }
        public string BaseUrl { get; set; }
        public IEnumerable<string> Rovers { get; set; }
    }
}
