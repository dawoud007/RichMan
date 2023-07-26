using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ElectronicsShop_service.Dtos
{
    public class CategoryDto : BaseDto
    {

        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int? DisplayOrder { get; set; }
    }
}
