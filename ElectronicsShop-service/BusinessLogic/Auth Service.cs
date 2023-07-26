/*using ElectronicsShop_service.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicsShop_service.Models
{
    public interface IUserService
    {
        User Authenticate(string username, string password);

       
    }

    public class UserService : IUserService
    {
		private readonly UserManager<User> _userManager;


        public async Task<User> Authenticate(string username, string password)
        {
            User user =await _userManager.FindByNameAsync(username);
            return user;
        }

	
	}
}

*/