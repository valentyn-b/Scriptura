using Microsoft.AspNetCore.Mvc;
using Scriptura.Domain.Repositories;

namespace Scriptura.Api.Endpoints;

public record CreateSettlementRequest(
    string CurrentName,
    string Type,
    string? ModernRegion = null,
    string? ModernDistrict = null,
    string? ModernCommunity = null
);

public record SettlementResponse(
    Guid Id,
    string CurrentName,
    string Type,
    string? ModernRegion
);

public static class SettlementsEndpoints
{
    public static void MapSettlementEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/settlements")
                       .WithTags("Settlements");

        group.MapPost("/", CreateSettlement);
    }

    private static async Task<IResult> CreateSettlement(
        [FromBody] CreateSettlementRequest request,
        [FromServices] ISettlementRepository repository,
        CancellationToken cancellationToken)
    {

        return Results.Ok(new { Message = "Settlement endpoint is ready for mapping!" });
    }
}