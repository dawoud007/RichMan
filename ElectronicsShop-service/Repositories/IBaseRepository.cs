#region Assembly Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null
// C:\Users\Mo Dawoud\.nuget\packages\commongenericclasses\8.0.0\lib\net6.0\Common.dll
// Decompiled with ICSharpCode.Decompiler 7.1.0.6543
#endregion

using CommonGenericClasses;
using ElectronicsShop_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ElectronicsShop_service.Repositories
{
	public interface IBaseRepository<TEntity> where TEntity : BaseEntity
	{
		Task<TEntity> AddAsync(TEntity entity);

		void Dispose();

		Task<TEntity> Edit(TEntity entity);

		Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string include = "");

		Task<List<TEntity>> GetAllAsync();

		Task<TEntity> GetByIdAsync(object id);

		TEntity Remove(TEntity entity);

		Task<TEntity> RemoveAsync(Expression<Func<TEntity, bool>> predicate);

		Task<TEntity> RemoveByIdAsync(object id);

		Task<IEnumerable<TEntity>> RemoveRangeAsync(Expression<Func<TEntity, bool>> predicate);
		Task Save();
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
