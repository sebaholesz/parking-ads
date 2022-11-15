using System.Text.Json.Serialization;

namespace ParkingService.ParkingSpotApi.Responses;

public record ParkingSpotApiResponse
{
    [JsonPropertyName("features")]
    public IReadOnlyList<ParkingSpotResponse> ParkingSpots { get; init; }
}
