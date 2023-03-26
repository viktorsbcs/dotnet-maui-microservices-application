using AutoMapper;
using PlatformService.DataTransferObjects;
using PlatformService.Models;

namespace PlatformService.AutoMapper
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<User, UserReadDto>();


        }
    }
}
