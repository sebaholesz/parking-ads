using System.Text.Json.Serialization;

namespace ParkingService.ParkingSpotApi.Responses;

public record PropertiesResponse
{
    [JsonPropertyName("adresse")]
    public string StreetName { get; init; }
    
    [JsonPropertyName("husnr")]
    public string StreetNumber { get; init; }
    
    [JsonPropertyName("bemaerkning")]
    public string Details { get; init; }
    
    [JsonPropertyName("oprettet_dato")]
    public string Created { get; init; }
    
    [JsonPropertyName("rettet_dato")]
    public string LastUpdated { get; init; }
}
