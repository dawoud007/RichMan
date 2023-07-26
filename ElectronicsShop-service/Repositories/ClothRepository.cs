using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Models;

namespace ElectronicsShop_service.Repositories;
public class ClothRepository : BaseRepository<Cloth>,IClothRepository
{
    public ClothRepository(ApplicationDbContext context) : base(context)
    {
    }

	
}

