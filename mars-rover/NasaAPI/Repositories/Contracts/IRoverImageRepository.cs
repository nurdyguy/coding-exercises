using NasaAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NasaAPI.Repositories.Contracts
{
    public interface IRoverImageRepository
    {
        RoverImage GetImage(int id);
        IEnumerable<RoverImage> SearchImages(DateTime date, string roverName, int page, int perPage);
        int SearchImagesCount(DateTime date, string roverName);
        Task<bool> SaveImages(IEnumerable<RoverImage> images);
    }
}
