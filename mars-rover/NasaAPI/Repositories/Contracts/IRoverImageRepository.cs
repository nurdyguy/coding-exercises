using NasaAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NasaAPI.Repositories.Contracts
{
    public interface IRoverImageRepository
    {
        RoverImage GetImage(int id);
        IEnumerable<RoverImage> SearchImages(IEnumerable<DateTime> dates, IEnumerable<string> roverNames, int page, int perPage);
        int SearchImagesCount(IEnumerable<DateTime> dates, IEnumerable<string> roverNames);
        Task<bool> SaveImages(IEnumerable<RoverImage> images);
    }
}
