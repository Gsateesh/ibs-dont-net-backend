using System.Text.Json.Nodes;
using IBS.Api.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IBS.Api.Swagger;

/// <summary>
/// Adds the bearer-token requirement and the 401/403 responses to every operation that is
/// not marked <see cref="AllowAnonymousAttribute"/>, so the document says who may call what
/// without each action repeating the same attributes.
/// </summary>
public sealed class AuthResponsesOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var allowsAnonymous =
            context.MethodInfo.GetCustomAttributes(true).OfType<AllowAnonymousAttribute>().Any() ||
            (context.MethodInfo.DeclaringType?.GetCustomAttributes(true).OfType<AllowAnonymousAttribute>().Any() ?? false);

        if (allowsAnonymous)
        {
            return;
        }

        operation.Responses ??= [];
        operation.Responses.TryAdd("401", new OpenApiResponse
        {
            Description = "No valid, unexpired bearer token was presented, or the account is no longer active."
        });
        operation.Responses.TryAdd("403", new OpenApiResponse
        {
            Description = "Signed in, but lacking the permission this action requires."
        });

        operation.Security =
        [
            new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference(SwaggerRegistration.SecuritySchemeId)] = []
            }
        ];
    }
}

/// <summary>
/// Surfaces the permission an endpoint requires in its Swagger description, reading the
/// <see cref="RequiresPermissionAttribute"/> the controller already carries. The rule and its
/// documentation therefore cannot drift apart.
/// </summary>
public sealed class PermissionSummaryOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var attributes = context.MethodInfo
            .GetCustomAttributes(true)
            .OfType<RequiresPermissionAttribute>()
            .ToList();

        if (attributes.Count == 0)
        {
            return;
        }

        var codes = attributes.SelectMany(a => a.PermissionCodes).Distinct().ToList();
        var note = codes.Count == 1
            ? $"**Requires the `{codes[0]}` permission.**"
            : $"**Requires one of: {string.Join(", ", codes.Select(c => $"`{c}`"))}.**";

        operation.Description = string.IsNullOrWhiteSpace(operation.Description)
            ? note
            : $"{operation.Description}\n\n{note}";
    }
}

/// <summary>
/// Lists the members of an enum in its schema description. Enums serialise as their string
/// names, so the document should name the values a caller may actually send.
/// </summary>
public sealed class EnumDescriptionSchemaFilter : ISchemaFilter
{
    public void Apply(IOpenApiSchema schema, SchemaFilterContext context)
    {
        if (!context.Type.IsEnum || schema is not OpenApiSchema concrete)
        {
            return;
        }

        var names = Enum.GetNames(context.Type);

        concrete.Type = JsonSchemaType.String;
        concrete.Format = null;
        concrete.Enum = [.. names.Select(n => (JsonNode)JsonValue.Create(n))];

        var listed = string.Join(", ", names);
        concrete.Description = string.IsNullOrWhiteSpace(concrete.Description)
            ? $"One of: {listed}."
            : $"{concrete.Description} One of: {listed}.";
    }
}
