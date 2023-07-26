using CommonGenericClasses;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop_service.Models;
public class Category : BaseEntity
{
    public Category()
    {
    }
    [Required]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Display Order")]
    public int? DisplayOrder { get; set; }

}