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
			return Ok((await _unitOfWork.ReadAllAsync()).Select((product) => _mapper.Map<TDto>(product)));
		}

		[HttpGet("{id}")]
		public virtual async Task<IActionResult> Get(Guid id)
		{
			TEntity source = await _unitOfWork.ReadByIdAsync(id);
			TDto value = _mapper.Map<TDto>(source);
			return Ok(value);
		}


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
#if false // Decompilation log
'322' items in cache
------------------
Resolve: 'System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Found single assembly: 'System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.13\ref\net6.0\System.Runtime.dll'
------------------
Resolve: 'Microsoft.EntityFrameworkCore, Version=6.0.7.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Found single assembly: 'Microsoft.EntityFrameworkCore, Version=6.0.18.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
WARN: Version mismatch. Expected: '6.0.7.0', Got: '6.0.18.0'
Load from: 'C:\Users\Mo Dawoud\.nuget\packages\microsoft.entityframeworkcore\6.0.18\lib\net6.0\Microsoft.EntityFrameworkCore.dll'
------------------
Resolve: 'System.Linq.Expressions, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Found single assembly: 'System.Linq.Expressions, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.13\ref\net6.0\System.Linq.Expressions.dll'
------------------
Resolve: 'Microsoft.AspNetCore.Mvc.Core, Version=2.2.5.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Found single assembly: 'Microsoft.AspNetCore.Mvc.Core, Version=6.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
WARN: Version mismatch. Expected: '2.2.5.0', Got: '6.0.0.0'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.AspNetCore.App.Ref\6.0.13\ref\net6.0\Microsoft.AspNetCore.Mvc.Core.dll'
------------------
Resolve: 'AutoMapper, Version=11.0.0.0, Culture=neutral, PublicKeyToken=be96cd2c38ef1005'
Found single assembly: 'AutoMapper, Version=12.0.0.0, Culture=neutral, PublicKeyToken=be96cd2c38ef1005'
WARN: Version mismatch. Expected: '11.0.0.0', Got: '12.0.0.0'
Load from: 'C:\Users\Mo Dawoud\.nuget\packages\automapper\12.0.1\lib\netstandard2.1\AutoMapper.dll'
------------------
Resolve: 'FluentValidation, Version=11.0.0.0, Culture=neutral, PublicKeyToken=7de548da2fbae0f0'
Found single assembly: 'FluentValidation, Version=11.0.0.0, Culture=neutral, PublicKeyToken=7de548da2fbae0f0'
Load from: 'C:\Users\Mo Dawoud\.nuget\packages\fluentvalidation\11.5.2\lib\net6.0\FluentValidation.dll'
------------------
Resolve: 'Microsoft.AspNetCore.Mvc.Abstractions, Version=2.2.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Found single assembly: 'Microsoft.AspNetCore.Mvc.Abstractions, Version=6.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
WARN: Version mismatch. Expected: '2.2.0.0', Got: '6.0.0.0'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.AspNetCore.App.Ref\6.0.13\ref\net6.0\Microsoft.AspNetCore.Mvc.Abstractions.dll'
------------------
Resolve: 'System.Collections, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Found single assembly: 'System.Collections, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.13\ref\net6.0\System.Collections.dll'
------------------
Resolve: 'Microsoft.EntityFrameworkCore.Relational, Version=6.0.7.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Found single assembly: 'Microsoft.EntityFrameworkCore.Relational, Version=6.0.18.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
WARN: Version mismatch. Expected: '6.0.7.0', Got: '6.0.18.0'
Load from: 'C:\Users\Mo Dawoud\.nuget\packages\microsoft.entityframeworkcore.relational\6.0.18\lib\net6.0\Microsoft.EntityFrameworkCore.Relational.dll'
------------------
Resolve: 'System.Linq, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Found single assembly: 'System.Linq, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.13\ref\net6.0\System.Linq.dll'
------------------
Resolve: 'System.Linq.Queryable, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Found single assembly: 'System.Linq.Queryable, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.13\ref\net6.0\System.Linq.Queryable.dll'
------------------
Resolve: 'Microsoft.EntityFrameworkCore.Abstractions, Version=6.0.18.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Found single assembly: 'Microsoft.EntityFrameworkCore.Abstractions, Version=6.0.18.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Load from: 'C:\Users\Mo Dawoud\.nuget\packages\microsoft.entityframeworkcore.abstractions\6.0.18\lib\net6.0\Microsoft.EntityFrameworkCore.Abstractions.dll'
------------------
Resolve: 'Microsoft.AspNetCore.Mvc.Abstractions, Version=6.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Found single assembly: 'Microsoft.AspNetCore.Mvc.Abstractions, Version=6.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.AspNetCore.App.Ref\6.0.13\ref\net6.0\Microsoft.AspNetCore.Mvc.Abstractions.dll'
------------------
Resolve: 'Microsoft.AspNetCore.Http.Extensions, Version=6.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Found single assembly: 'Microsoft.AspNetCore.Http.Extensions, Version=6.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Load from: 'C:\Program Files\dotnet\packs\Microsoft.AspNetCore.App.Ref\6.0.13\ref\net6.0\Microsoft.AspNetCore.Http.Extensions.dll'
------------------
Resolve: 'Microsoft.EntityFrameworkCore, Version=6.0.18.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Found single assembly: 'Microsoft.EntityFrameworkCore, Version=6.0.18.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
Load from: 'C:\Users\Mo Dawoud\.nuget\packages\microsoft.entityframeworkcore\6.0.18\lib\net6.0\Microsoft.EntityFrameworkCore.dll'
#endif
