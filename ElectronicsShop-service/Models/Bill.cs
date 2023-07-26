using CommonGenericClasses;
using ElectronicsShop_service.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop_service.Models
{
	public class Bill:BaseEntity

	{
		public Bill() {

			Suits = new List<Cloth>();
		}

	
		public string BuyerName { get; set; }
		public string SellerName { get; set; }
		public string Description { get; set; }
		public int NumberOfPieces { get; set; }

		// Relationship: Each Bill contains multiple Cloth items
		public ICollection<Cloth> Suits { get; set; }




	}
}
