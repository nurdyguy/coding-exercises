using NasaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NasaAPI.Services.Contracts
{
    public interface INasaApiService
    {
        Task GetSaveRoverData();
    }
}
