
using ElectronicsShop_service.BusinessLogic;
using ElectronicsShop_service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Mapster;
using System.Text;
using ElectronicsShop_service.IdentityHandler;
using Authentication.Infrastructure.Models;
using Microsoft.Extensions.Options;
using static ElectronicsShop_service.Controllers.AuthController;

namespace ElectronicsShop_service.Controllers;
[ApiController]
[Route("[controller]")]

public class AuthController : ControllerBase
{
	private readonly IConfiguration _configuration;
	private readonly RoleManager<ApplicationRole> _roleManager;
	private readonly UserManager<User> _userManager;
/*	private readonly ITokenGenerator _tokenGenerator;*/


	public AuthController(IConfiguration configuration, UserManager<User> userManager, RoleManager<ApplicationRole> roleManager)
	{
		_configuration = configuration;
		_userManager = userManager;
		_roleManager = roleManager;
	/*	_tokenGenerator = tokenGenerator;*/


	}


	[HttpPut("ChangeUserRole/{name}")]
	public async Task<IActionResult> ChangeUserRole(string name, [FromBody] string newRoleName)
	{
		// Find the user
		var user = await _userManager.FindByNameAsync(name);
		if (user == null)
		{
			return NotFound();
		}
		
		// Find the new role
		var newRole = await _roleManager.FindByNameAsync(newRoleName);
		if (newRole == null)
		{
			return NotFound("Role not found");
		}

		user.Role = newRoleName;
		await _userManager.UpdateAsync(user);





		return Ok($"User role changed successfully changed to { user.Role}");
	}
	[HttpPost("login")]
	
	public async Task<IActionResult> Login([FromBody] LoginModel model)
	{
		User user = await _userManager.FindByNameAsync(model.Username);

		if (user == null)
			return BadRequest (new { Message = "user does not exist" }); 
		if (!await _userManager.CheckPasswordAsync(user, model.Password))
		{
			return BadRequest(new { Message = "password is not correct" });
		}



		var token = GenerateJwtTokehn(user);
		return Ok(new { Token = token });
	}
	[HttpPost("signup")]
	[AllowAnonymous]
	public async Task<IActionResult> SignUp([FromBody] SignUpModel model)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest("fill all colums");
		}
		// Check if the username already exists
		var existingUser = _userManager.FindByNameAsync(model.UserName);
		if (existingUser == null)
		{
			return BadRequest("Username already exists. Please choose a different username.");
		}
		if (model.Role != "User" && model.Role != "Admin")
		{
			return BadRequest("Role value is not set probely");
		}
		// You may add more validations here if needed.

		// Create a new user and add it to the user list.


		var user = model.Adapt<User>();


		var result = await _userManager.CreateAsync(user, model.Password);
		if (result.Succeeded)
		{

			return Ok(user);
		}
		else
		{
			// Handle user creation failure
			return BadRequest(result.Errors.FirstOrDefault()?.Description);
		}



	}

	private string GenerateJwtTokehn(User user)
	{
		var jwtSection = _configuration.GetSection("Jwt");
		var Expiry = jwtSection.GetValue<double>("Expiry");
		var Issuer = jwtSection.GetValue<string>("Issuer");
		var Audience = jwtSection.GetValue<string>("Audience");



		var key = jwtSection.GetValue<string>("key");

		if (string.IsNullOrEmpty(key))
		{
			throw new InvalidOperationException("Jwt:Key is not configured or is empty.");
		}

		Claim[] claims = new Claim[]{
			new (ClaimTypes.NameIdentifier,user.UserName!),
			new (ClaimTypes.Role,user.Role!),
			new (ClaimTypes.PrimarySid,user.Id.ToString())
		};

		var signingCredentials = new SigningCredentials(
			new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes(key)
			),
			SecurityAlgorithms.HmacSha256);

		var jwtSecurityToken = new JwtSecurityToken(
			issuer: Issuer,
			audience: Audience,
			claims: claims,
			notBefore: null,
			expires: DateTime.Now.AddHours(Expiry),
			signingCredentials: signingCredentials
		);

		var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
		return token;
	}


	// ... Other existing code ...

	[HttpPost("changeProfile")]
	[AllowAnonymous]

	public async Task<IActionResult> ChangeProfile([FromBody] ChangeProfileModel model)
	{
		User user = await _userManager.FindByNameAsync(model.UserName);

		if (user == null)
			return NotFound("User not found.");

		// Admin can change both name and password for any user.
		if (model.NewUserName != null)
			user.UserName = model.NewUserName;

		if (model.NewPassword != null)
		{
			var passwordValidator = new PasswordValidator<User>();
			var validationResult = await passwordValidator.ValidateAsync(_userManager, null, model.NewPassword);

			if (!validationResult.Succeeded)
				return BadRequest("Invalid password format.");

			var token = await _userManager.GeneratePasswordResetTokenAsync(user);
			await _userManager.ResetPasswordAsync(user, token, model.NewPassword);
		}

		await _userManager.UpdateAsync(user);

		return Ok("Profile updated successfully.");
	}





}
public class ChangeProfileModel
{
	public string? UserName { get; set; }
	public string? NewUserName { get; set; }
	public string? NewPassword { get; set; }
}
public class LoginModel
{
	public string? Username { get; set; }
	public string? Password { get; set; }
}

public class SignUpModel
{
	public string? UserName { get; set; }
	public string? Password { get; set; }
	public string? Role { get; set; }

}

