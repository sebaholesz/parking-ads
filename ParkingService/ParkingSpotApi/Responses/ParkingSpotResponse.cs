using System.Text.Json.Serialization;

namespace ParkingService.ParkingSpotApi.Responses;

public record ParkingSpotResponse
{
    [JsonPropertyName("geometry")]
    public GeometryResponse Geometry { get; init; }
    
    [JsonPropertyName("properties")]
    public PropertiesResponse Properties { get; init; }
}
