using System.Text.Json.Serialization;

namespace ParkingService.ParkingSpotApi.Responses;

public record GeometryResponse
{
    [JsonPropertyName("coordinates")]
    public IReadOnlyList<double> Coordinates { get; init; }
}
