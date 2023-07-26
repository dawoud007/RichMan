using AutoMapper;
using ElectronicsShop_service.Dtos;
using ElectronicsShop_service.Models;

namespace ElectronicsShop_service.MapperProfiles;
public class ClothMappings : Profile
{
    public ClothMappings()
    {
        CreateMap<Cloth, ClothDto>()
 
        .ReverseMap();


		CreateMap<ClothDtos, ClothDto>()

	  .ReverseMap();
	}
}