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

        public IEnumerable<RoverImage> SearchImages(IEnumerable<DateTime> dates, IEnumerable<string> roverNames, int page, int perPage)
        {
            var imgs = (_cache.Get<IEnumerable<RoverImage>>(_cacheKey) ?? new List<RoverImage>())
                .Where(i => dates.Contains(i.EarthDate) && roverNames.Contains(i.Rover.Name));
            return imgs.Skip((page - 1) * perPage).Take(perPage);
        }

        public int SearchImagesCount(IEnumerable<DateTime> dates, IEnumerable<string> roverNames)
        {
            var imgs = (_cache.Get<IEnumerable<RoverImage>>(_cacheKey) ?? new List<RoverImage>())
                .Where(i => dates.Contains(i.EarthDate) && roverNames.Contains(i.Rover.Name));
            return imgs.Count();
        }

        public async Task<bool> SaveImages(IEnumerable<RoverImage> images)
        {
            _cache.Set("roverImages", images);
            return true;
        }
    }
}
