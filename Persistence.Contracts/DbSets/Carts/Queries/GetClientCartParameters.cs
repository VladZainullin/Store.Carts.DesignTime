// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Persistence.Contracts.DbSets.Carts.Queries;

public readonly struct GetClientCartParameters
{
    public required Guid ClientId { get; init; }

    public required bool AsTracking { get; init; }

    public required bool IncludeProducts { get; init; }
}