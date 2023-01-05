using ParkingAdsApi.ApiClients.ParkingClient;

namespace ParkingAdsApi.Models;

public class ParkingResponse
{
    public IEnumerable<ParkingSpot> ParkingSpots { get; set; }
    public IEnumerable<string> Ads { get; set; }
}