using AutoMapper;
using MarsRoverTest.Models;
using System.Linq;

namespace MarsRoverTest.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<NasaAPI.Models.RoverImage, RoverImage>()
                .ForMember(dest => dest.ImageType, opt => opt.MapFrom(src => src.FileType));

            CreateMap<NasaAPI.Models.Rover, Rover>();
            CreateMap<NasaAPI.Models.RoverCamera, RoverCamera>();
        }
    }
}
