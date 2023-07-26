using CommonGenericClasses;
using ElectronicsShop_service.Models;

namespace ElectronicsShop_service.Models
{
	public class Store:BaseEntity
	{
	
		public string? Name { get; set; }

		// Relationship: Each Store stores multiple Cloth items
		public ICollection<Cloth>? StoredSuits { get; set; }




		public int GetTotalNumberOfSuits()
		{
			return StoredSuits.Sum(s => s.NumOfPieces);
		}

	}
}
