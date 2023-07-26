using CommonGenericClasses;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Models;
using ElectronicsShop_service.Repositories;

namespace ElectronicsShop_service.BusinessLogic
{
    public class CategoryBusiness : BaseUnitOfWork<Category>, ICategoryUnitOfWork
    {
        public CategoryBusiness(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }
    }
}
