using ElectronicsShop_service.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ElectronicsShop_service.IdentityHandler;

public class IdentityOptionsSetup : IConfigureOptions<IdentityOptions>
{
	public void Configure(IdentityOptions options)
	{
		options.Password.RequireNonAlphanumeric = false;

		options.SignIn.RequireConfirmedEmail = true;
	}
}

public class ApplicationRole : IdentityRole<string>
{

	public int  userId { get; set; }
}