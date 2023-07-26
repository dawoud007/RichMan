using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace Authentication.Infrastructure.Models;
public record Jwt
{
    public string Issuer { get; init; } = string.Empty;
    public string Audience { get; init; } = string.Empty;
    public string Key { get; init; } = string.Empty;
    public int Expiry { get; init; }
}



public class AuthorizeOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var requiredRoles = context.MethodInfo.GetCustomAttributes(true)
            .OfType<AuthorizeAttribute>()
            .Select(attr => attr.Roles)
            .FirstOrDefault();

        if (!string.IsNullOrEmpty(requiredRoles))
        {
            operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
                        new List<string> { requiredRoles }
                    }
                }
            };
        }
    }
}
