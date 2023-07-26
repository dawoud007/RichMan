/*using AutoMapper;
using CommonGenericClasses;
using ElectronicsShop_service.Dtos;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop_service.Controllers;
[ApiController]
[Route("[controller]/[action]")]
*//*[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]*//*
public class StoreController : BaseController<Store, StoreDto>
{
    public StoreController(IStoreUnitOfWork unitOfWork, IMapper mapper, IValidator<Store> validator) : base(unitOfWork, mapper, validator)
    {

    }

    [DisplayName("GetAll")]
    public override Task<IActionResult> Get()
    {
        return base.Get();
    }

}


*/