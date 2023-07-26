using AutoMapper;
using ElectronicsShop_service.Dtos;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.MapperProfiles;
using ElectronicsShop_service.Models;
using ElectronicsShop_service.Repositories;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net.Security;

namespace ElectronicsShop_service.Controllers;
[ApiController]
[Route("[controller]/[action]")]

public class BillController : MyBaseController<Bill, BillDto>
{
	private readonly IBillRepository _billRepository;
	private readonly IClothRepository _clothRepository;
    public BillController(IBillRepository billRepository,IClothRepository clothRepository,  IBillUnitOfWork unitOfWork, IMapper mapper, IValidator<Bill> validator) : base(unitOfWork, mapper, validator)
    {
		_billRepository= billRepository;
		_clothRepository= clothRepository;
    }


	public override async Task<IActionResult> Get()
	{
	
		var results = await _billRepository.GetAllAsync();
	

		foreach (var bill in results)
		{
		var thing = (await _clothRepository.Get(c =>c.BillId==bill.Id)).ToList();
			bill.Suits=thing;
			
			

		}
		return Ok(results);
	}



	public override async Task<IActionResult> Get(Guid id)
	{
		var result = await _billRepository.GetByIdAsync(id);	
		var billSuits=(await _clothRepository.Get(c=>c.BillId==id)).ToList();
		result.Suits = billSuits;
		return Ok(result);
	}








	[HttpPost]
	public  async override Task<IActionResult> Post([FromBody] BillDto billDto)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		var list=new List<Cloth>();
		
		foreach(var suit in billDto.Suits!)
		{
			list.Add(suit);

		}
		var bill = new Bill
		{
			BuyerName = billDto.BuyerName,
			SellerName = billDto.SellerName,
			Description = billDto.Description!,
			Suits= list
		};

		try
		{
			await _billRepository.AddAsync(bill);

			if (billDto.Suits != null && billDto.Suits.Any())
			{
				foreach (var suitDto in billDto.Suits)
				{  var suits = await FindSuitWithFeatures(suitDto);
					if (suitDto != null)
					{
						if (suitDto.NumOfPieces <= suits.NumOfPieces)
						{
							suits.NumOfPieces -=suitDto.NumOfPieces;
							
						}
						else
						{
							return BadRequest($"Not enough suits available with Size: {suitDto.Size}, Color: {suitDto.Color}, Type: {suitDto.type}");
						}
					}
					else
					{
						return BadRequest($"Suit not found with Size: {suitDto.Size}, Color: {suitDto.Color}, Type: {suitDto.type}");
					}
				}
			}

			await _billRepository.Save();
			return Ok(bill);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.InnerException?.Message ?? ex.Message);
		}
	}
	
	private async Task<Cloth> FindSuitWithFeatures(Cloth suitDto)
	{
	
		var s =(await _clothRepository.Get(c =>
			c.Size == suitDto.Size &&
			c.Color == suitDto.Color&&
			c.StoreName == suitDto.StoreName &&

			c.type == suitDto.type,null,"")).ToList().FirstOrDefault()!;
		
		return s;
	}



}


