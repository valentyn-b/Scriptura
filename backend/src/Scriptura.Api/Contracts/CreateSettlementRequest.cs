namespace Scriptura.Api.Contracts;

public record CreateSettlementRequest(
    string CurrentName,
    string Type,
    string? ModernRegion = null,
    string? ModernDistrict = null,
    string? ModernCommunity = null
);
