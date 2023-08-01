using CommonGenericClasses;
using ElectronicsShop_service.Models;
using static ElectronicsShop_service.Controllers.ClothController;

namespace ElectronicsShop_service.Interfaces;
public interface IClothRepository : IBaseRepo<Cloth>
{
    Task<List<Cloth>> GetFiltered(ClothSearchDto searchDto);
}