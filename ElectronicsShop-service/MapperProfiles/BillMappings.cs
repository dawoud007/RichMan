using AutoMapper;
using ElectronicsShop_service.Dtos;
using ElectronicsShop_service.Models;

namespace ElectronicsShop_service.MapperProfiles;
public class BillMappings : Profile
{
    public BillMappings()
    {
        CreateMap<Bill, BillDto>()
 
        .ReverseMap();
    }
}