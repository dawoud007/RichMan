using CommonGenericClasses;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Models;
using ElectronicsShop_service.Repositories;

namespace ElectronicsShop_service.BusinessLogic
{
    public class StoreBusiness : BaseUnitOfWork<Store>, IStoreUnitOfWork
    {
        public StoreBusiness(IStoreRepository storeRepository) : base(storeRepository)
        {
        }
    }
}
