using CommonGenericClasses;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Models;
using ElectronicsShop_service.Repositories;

namespace ElectronicsShop_service.BusinessLogic
{
    public class BillBusiness : BaseUnitOfWork<Bill>, IBillUnitOfWork
    {
        public BillBusiness(IBillRepository billRepository) : base(billRepository)
        {
        }
    }
}
