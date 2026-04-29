using Microsoft.AspNetCore.Mvc;
using Scriptura.Api.Contracts;
using Scriptura.Domain.Entities.Catalog;
using Scriptura.Domain.Enums;
using Scriptura.Domain.Repositories;
using Scriptura.Domain.ValueObjects;

namespace Scriptura.Api.Endpoints;

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
        if (!Enum.TryParse<SettlementType>(request.Type, ignoreCase: true, out var settlementType))
        {
            return Results.BadRequest(new { Message = $"Invalid settlement type: '{request.Type}'." });
        }

        ModernDivision? modernDivision = null;
        if (!string.IsNullOrWhiteSpace(request.ModernRegion))
        {
            modernDivision = new ModernDivision(
                request.ModernRegion,
                request.ModernDistrict,
                request.ModernCommunity);
        }

        Coordinate? location = null;

        var settlement = Settlement.Create(
            request.CurrentName,
            settlementType,
            modernDivision,
            location);

        repository.Add(settlement);
        await repository.SaveChangesAsync(cancellationToken);

        var response = new SettlementResponse(
            settlement.Id,
            settlement.CurrentName,
            settlement.Type.ToString(),
            settlement.ModernAdminDivision?.Region
        );

        return Results.Created($"/api/settlements/{settlement.Id}", response);
    }
}