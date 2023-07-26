using CommonGenericClasses;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop_service.Models
{
    public class User : IdentityUser
	{

        [Key]
        public int Id { get; set; }
        [Required]
        public override string?  UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Role { get; set; }

		public DateTime CreationDate { get; set; }
	}

   



}
