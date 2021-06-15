using Microsoft.Extensions.Options;
using NasaAPI.Models;
using NasaAPI.Models.ResponseModels;
using NasaAPI.Services.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NasaAPI.Services.Implementations
{
    public class NasaApiService : INasaApiService
    {
        private readonly NasaApiProperties _properties;
        public NasaApiService(IOptions<NasaApiProperties> properties)
        {
            _properties = properties.Value;
        }
        public async Task GetSaveRoverData()
        {
            string text = File.ReadAllText(@"./dates.txt");
            var dates = new List<DateTime>();
            foreach(var d in text.Split('\n'))
            {
                if (DateTime.TryParse(d, out var date))
                    dates.Add(date);
            }

            var t1 = new List<Task<IEnumerable<RoverImage>>>();
            foreach (var d in dates)
                foreach (var r in _properties.Rovers)
                    t1.Add(ProcessImageDate(d, r));

            await Task.WhenAll(t1);
            var imageDetails = t1.SelectMany(im => im.Result);

            var t2 = imageDetails.Select(im => GetImageFile(im));
            await Task.WhenAll(t2);


        }

        private async Task<IEnumerable<RoverImage>> ProcessImageDate(DateTime date, string roverName)
        {
            var images = new List<RoverImage>();
            try
            {
                var client = new RestClient($"{_properties.BaseUrl}/{roverName}/photos?earth_date={date.ToString("yyyy-MM-dd")}&api_key={_properties.ApiKey}");
                var response = await client.ExecuteAsync(new RestRequest(Method.GET));
                if (response.IsSuccessful)
                {
                    images = JsonConvert.DeserializeObject<List<RoverImage>>(JObject.Parse(response.Content).SelectToken("photos").ToString());
                }
            }
            catch(Exception ex)
            {
                // log exception...
            }
            return images;
        }

        private async Task GetImageFile(RoverImage image)
        {
            var imgType = image.ImageSource.Split('.').Last();
            var filename = $"{image.Rover.Name}_{image.Camera.Abbreviation}_{image.EarthDate.ToString("yyyy_MM_dd")}_{image.Id}";
            var client = new RestClient(image.ImageSource);            
            var result = await client.ExecuteAsync(new RestRequest(Method.GET));
            if(result.IsSuccessful)
            {
                File.WriteAllBytes(Path.Combine("../NasaAPI/Repositories/Images", $"{filename}.{imgType}"), result.RawBytes);
            }
        }
    }
}
