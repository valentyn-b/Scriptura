using Microsoft.AspNetCore.Mvc;
using Scriptura.Domain.Repositories;
using Scriptura.Api.Contracts;

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

        return Results.Ok(new { Message = "Settlement endpoint is ready for mapping!" });
    }
}