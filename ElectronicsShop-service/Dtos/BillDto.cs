using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ElectronicsShop_service.Models;

namespace ElectronicsShop_service.Dtos
{
    public class BillDto : BaseDto
    {


		public string BuyerName { get; set; } = "";
		public string SellerName { get; set; } = "";

		public string? Description { get; set; }
		public string? WarningToNumberOfPieces { get; set; } = "warning there are only 10 pieces of this kind of suits";

        public List<Cloth>? Suits { get; set; }
	}
	
}
