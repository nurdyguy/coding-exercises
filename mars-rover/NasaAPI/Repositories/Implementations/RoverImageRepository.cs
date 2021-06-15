using Microsoft.Extensions.Caching.Memory;
using NasaAPI.Models;
using NasaAPI.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NasaAPI.Repositories.Implementations
{
    public class RoverImageRepository : IRoverImageRepository
    {
        private readonly string _cacheKey = "roverImages";
        private IMemoryCache _cache;
        public RoverImageRepository(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }
        public RoverImage GetImage(int id)
        {
            return _cache.Get<IEnumerable<RoverImage>>(_cacheKey).SingleOrDefault(ri => ri.Id == id);
        }

        public IEnumerable<RoverImage> SearchImages(DateTime date, string roverName, int page, int perPage)
        {
            var imgs = _cache.Get<IEnumerable<RoverImage>>(_cacheKey);
            if(DateTime.Compare(date, new DateTime()) != 0)
                imgs = imgs.Where(i => i.EarthDate == date);
            if (!string.IsNullOrWhiteSpace(roverName))
                imgs = imgs.Where(i => i.Rover.Name == roverName);            
            return imgs.Skip((page - 1) * perPage).Take(perPage);
        }

        public int SearchImagesCount(DateTime date, string roverName)
        {
            var imgs = _cache.Get<IEnumerable<RoverImage>>(_cacheKey);
            if (DateTime.Compare(date, new DateTime()) != 0)
                imgs = imgs.Where(i => i.EarthDate == date);
            if (!string.IsNullOrWhiteSpace(roverName))
                imgs = imgs.Where(i => i.Rover.Name == roverName);
            return imgs.Count();
        }

        public async Task<bool> SaveImages(IEnumerable<RoverImage> images)
        {
            _cache.Set("roverImages", images);
            return true;
        }
    }
}
