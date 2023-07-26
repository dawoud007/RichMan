using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ElectronicsShop_service.Models;

namespace ElectronicsShop_service.Dtos
{
    public class BillDto : BaseDto
    {


		public string BuyerName { get; set; } = "";
		public string SellerName { get; set; } = "";
		public int NumberOfPieces { get; set; }
		public string? Description { get; set; }



		public List<Cloth>? Suits { get; set; }
	}
	
}
