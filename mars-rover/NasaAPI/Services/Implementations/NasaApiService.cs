using Microsoft.Extensions.Options;
using NasaAPI.Models;
using NasaAPI.Models.RequestModels;
using NasaAPI.Models.ResponseModels;
using NasaAPI.Repositories.Contracts;
using NasaAPI.Services.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace NasaAPI.Services.Implementations
{
    public class NasaApiService : INasaApiService
    {
        private readonly NasaApiProperties _properties;
        private readonly IRoverImageRepository _imageRepo;
        private readonly int _perPageMax = 25;
        public NasaApiService(IOptions<NasaApiProperties> properties, IRoverImageRepository imageRepo)
        {
            _properties = properties.Value;
            _imageRepo = imageRepo;
        }

        public async Task GetSaveRoverData()
        {
            // keeps us from rerunning fetch on page reload if cache already built
            if (!_imageRepo.GetAllImages()?.Any() ?? true)
            {
                var dateStrs = File.ReadAllLines(@"./dates.txt");
                var dates = new List<DateTime>();
                foreach (var d in dateStrs)
                    if (DateTime.TryParse(d, out var date))
                        dates.Add(date);

                var t1 = dates.SelectMany(d => _properties.Rovers, (d, r) => ProcessImageDate(d, r));
                await Task.WhenAll(t1);
                var imageDetails = t1.SelectMany(im => im.Result).ToList();

                var t2 = imageDetails.Select(im => GetImageFile(im));
                await Task.WhenAll(t2);

                await _imageRepo.SaveImages(imageDetails);
            }
        }

        public SearchOptionsResponse GetSearchOptions()
        {
            var dateStrs = File.ReadAllLines(@"./dates.txt");
            var dates = new List<DateTime>();
            foreach (var d in dateStrs)
                if (DateTime.TryParse(d, out var date))
                    dates.Add(date);

            var images = _imageRepo.GetAllImages();

            var response = new SearchOptionsResponse()
            {
                Dates = dates,
                Rovers = images.Select(i => i.Rover.Name).Distinct()
            };
            return response;
        }

        public RoverImage GetImage(int id)
        {
            return _imageRepo.GetImage(id);
        }

        public SearchImagesResponse SearchImages(SearchImagesRequest request)
        {
            var perPage = Math.Min(request.PerPage, _perPageMax);
            return new SearchImagesResponse()
            {
                Page = request.Page,
                PerPage = perPage,
                RoverImages = _imageRepo.SearchImages(request.Dates, request.RoverNames, request.Page, perPage),
                Total = _imageRepo.SearchImagesCount(request.Dates, request.RoverNames)
            };
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
            var filename = $"{image.Rover.Name}_{image.Camera.Abbreviation}_{image.EarthDate.ToString("yyyy_MM_dd")}_{image.Id}.{image.ImageSource.Split('.').Last()}";
            var client = new RestClient(image.ImageSource);            
            var result = await client.ExecuteAsync(new RestRequest(Method.GET));
            if(result.IsSuccessful)
            {
                File.WriteAllBytes(Path.Combine("../NasaAPI/Repositories/Images", filename), result.RawBytes);
                image.ImageFilename = filename;
            }
        }
    }
}
