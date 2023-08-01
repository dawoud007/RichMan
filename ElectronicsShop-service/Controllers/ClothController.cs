using AutoMapper;
using ElectronicsShop_service.Dtos;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Models;
using ElectronicsShop_service.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop_service.Controllers;
[ApiController]
[Route("[controller]/[action]")]
/*[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]*/
public class ClothController : MyBaseController<Cloth, ClothDto>
{
	private readonly IClothRepository _clothRepository;
    private readonly ApplicationDbContext _context;
	public ClothController(IClothUnitOfWork unitOfWork, IMapper mapper, IClothRepository clothRepository, IValidator<Cloth> validator) : base(unitOfWork, mapper, validator)
    {
		_clothRepository = clothRepository;
	}

    [DisplayName("GetAll")]
    public override Task<IActionResult> Get()
    {
        return base.Get();
    }

    /*   [HttpGet]
       public virtual async Task<IActionResult> Get([FromQuery] string clothName)
       {
           return Ok((await _unitOfWork.ReadAsync(b => b.Name == clothName, null, "")).FirstOrDefault()!);
       }*/
    [HttpGet("Search")]
    public async Task<IActionResult> Search([FromQuery] ClothSearchDto searchDto)
    {
        var result = await _clothRepository.GetFiltered(searchDto);
        if(result.Count==0)
        {
            return NotFound("there is not matching products");
        }
        return Ok(result);
    }
  

    public class ClothSearchDto
    {
        public string? Name { get; set; }
        public int? Size { get; set; }
        public string? Color { get; set; }
        public string? Make { get; set; }
    }

}


