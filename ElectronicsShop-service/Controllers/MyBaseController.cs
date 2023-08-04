#region Assembly Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null
// C:\Users\Mo Dawoud\.nuget\packages\commongenericclasses\8.0.0\lib\net6.0\Common.dll
// Decompiled with ICSharpCode.Decompiler 7.1.0.6543
#endregion

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommonGenericClasses;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsShop_service.Controllers
{
	[ApiController]
	/*	[Authorize(AuthenticationSchemes = "Bearer")]*/
	[Route("api/[controller]")]
	public abstract class MyBaseController<TEntity, TDto> : ControllerBase where TEntity : BaseEntity where TDto : BaseDto
	{
		protected readonly IBaseUnitOfWork<TEntity> _unitOfWork;

		protected IMapper _mapper;

		protected readonly IValidator<TEntity> _validator;

		public MyBaseController(IBaseUnitOfWork<TEntity> unitOfWork, IMapper mapper, IValidator<TEntity> validator)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_validator = validator;
		}

		[HttpDelete("{id}")]
		public virtual async Task<ActionResult> Delete(Guid id)
		{
			TEntity entity = await _unitOfWork.DeleteByIdAsync(id);
			await _unitOfWork.SaveAsync();
			return Ok(_mapper.Map<TDto>(entity));
		}

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var x = (await _unitOfWork.ReadAllAsync()).Select((product) => _mapper.Map<TDto>(product)).FirstOrDefault();
            return Ok(x);
        }

        /*	[HttpGet("{id}")]
            public virtual async Task<IActionResult> Get(Guid id)
            {
                TEntity source = await _unitOfWork.ReadByIdAsync(id);
                TDto value = _mapper.Map<TDto>(source);
                return Ok(value);
            }*/




        [HttpPost]
		/*[Authorize(Roles ="Admin")]*/
		public virtual async Task<IActionResult> Post([FromBody] TDto entityViewModel)
		{
			TEntity entity = _mapper.Map<TEntity>(entityViewModel);
			ValidationResult validationResult = await _validator.ValidateAsync(entity);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors.Select((e) => e.ErrorMessage));
			}

			entity = await _unitOfWork.CreateAsync(entity);
			try
			{
				await _unitOfWork.SaveAsync();
				return CreatedAtAction("Get", new
				{
					id = entity.Id
				}, entity);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.InnerException!.Message);
			}
		}

		[HttpPut]
		public virtual async Task<IActionResult> Put([FromBody] TDto dto)
		{
			TEntity val = _mapper.Map<TEntity>(dto);
			ValidationResult validationResult = _validator.Validate(val);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors.Select((e) => e.ErrorMessage));
			}

			await _unitOfWork.Update(val);
			try
			{
				await _unitOfWork.SaveAsync();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return Ok(_mapper.Map<TDto>(dto));
		}
	}
}
