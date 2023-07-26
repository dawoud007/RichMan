using CommonGenericClasses;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Models;
using ElectronicsShop_service.Repositories;

namespace ElectronicsShop_service.BusinessLogic
{
    public class ClothBusiness : BaseUnitOfWork<Cloth>, IClothUnitOfWork
    {
        public ClothBusiness(IClothRepository clothRepository) : base(clothRepository)
        {
        }
    }
}
