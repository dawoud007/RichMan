using AutoMapper;
using ElectronicsShop_service.Dtos;
using ElectronicsShop_service.Models;

namespace ElectronicsShop_service.MapperProfiles;
public class StoreMappings : Profile
{
    public StoreMappings()
    {
        CreateMap<Store, StoreDto>()
 
        .ReverseMap();
    }
}