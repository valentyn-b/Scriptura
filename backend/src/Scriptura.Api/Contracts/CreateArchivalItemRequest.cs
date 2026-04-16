namespace Scriptura.Api.Contracts;

public record CreateArchivalItemRequest(
    string Title,
    string ArchiveCode,
    string Fond,
    string Inventory,
    string ItemNumber,
    string Type
);