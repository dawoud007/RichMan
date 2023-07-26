using CommonGenericClasses;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Models;

namespace ElectronicsShop_service.Repositories;
public class StoreRepository : BaseRepo<Store>,IStoreRepository
{
    public StoreRepository(ApplicationDbContext context) : base(context)
    {
    }
}