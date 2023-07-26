using AutoMapper;
using ElectronicsShop_service.Dtos;
using ElectronicsShop_service.Models;

namespace ElectronicsShop_service.MapperProfiles;
public class CategoryMappings : Profile
{
    public CategoryMappings()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>()
        .ReverseMap();
    }
}