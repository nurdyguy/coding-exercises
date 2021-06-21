using NasaAPI.Models;
using NasaAPI.Models.RequestModels;
using NasaAPI.Models.ResponseModels;
using System.Threading.Tasks;

namespace NasaAPI.Services.Contracts
{
    public interface INasaApiService
    {
        Task GetSaveRoverData();
        RoverImage GetImage(int id);
        SearchImagesResponse SearchImages(SearchImagesRequest request);
        SearchOptionsResponse GetSearchOptions();

    }
}
