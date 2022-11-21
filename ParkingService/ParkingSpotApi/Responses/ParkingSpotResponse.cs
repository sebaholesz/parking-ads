using System.Text.Json.Serialization;

namespace ParkingService.ParkingSpotApi.Responses;

public record ParkingSpotResponse
{
    [JsonPropertyName("date")]
    public string Created { get; init; }
    
    [JsonPropertyName("name")]
    public string Name { get; init; }
    
    /// <summary>
    /// The coordinates are in the format: "longitude,latitude" inside a string.
    /// </summary>
    [JsonPropertyName("coord")]
    public string Coordinates { get; init; }
    
    [JsonPropertyName("max")]
    public string Capacity { get; init; }
    
    /// <summary>
    /// The number of currently occupied spots.
    /// </summary>
    [JsonPropertyName("current")]
    public string CurrentlyInUse { get; init; }
}
