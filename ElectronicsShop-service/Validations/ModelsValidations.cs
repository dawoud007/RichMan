using ElectronicsShop_service.Models;
using FluentValidation;

namespace ElectronicsShop_service.Validations
{
    public class CategoryValidations : AbstractValidator<Category>
    {
        public CategoryValidations()
        {

        }
    }


	public class ClothValidations : AbstractValidator<Cloth>
	{
		public ClothValidations()
		{

		}
	}
	public class BillValidations : AbstractValidator<Bill>
	{
		public BillValidations()
		{

		}
	}
	public class StoreValidations : AbstractValidator<Store>
	{
		public StoreValidations()
		{

		}
	}
}