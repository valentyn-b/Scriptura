using Microsoft.AspNetCore.Mvc;
using Scriptura.Api.Contracts;
using Scriptura.Domain.Repositories;

namespace Scriptura.Api.Endpoints;

public static class ArchivalItemsEndpoints
{
    public static void MapArchivalItemEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/archival-items")
                       .WithTags("Archival Items");

        group.MapGet("/{id:guid}", GetArchivalItemById);
    }    

    private static async Task<IResult> GetArchivalItemById(
        Guid id,
        [FromServices] IArchivalItemRepository repository,
        CancellationToken cancellationToken)
    {
        var item = await repository.GetByIdWithScansAsync(id, cancellationToken);

        if (item is null)
            return Results.NotFound(new { Message = $"Archival item with ID {id} not found." });

        var response = new ArchivalItemResponse(
            item.Id,
            item.Title,
            $"{item.Signature.ArchiveCode} {item.Signature.Fond}-{item.Signature.Inventory}-{item.Signature.ItemNumber}",
            item.Type.ToString());

        return Results.Ok(response);
    }
}