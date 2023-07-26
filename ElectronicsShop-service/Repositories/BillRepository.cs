using CommonGenericClasses;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Models;

namespace ElectronicsShop_service.Repositories;
public class BillRepository : BaseRepo<Bill>, IBillRepository
{
    public BillRepository(ApplicationDbContext context) : base(context)
    {
    }
}