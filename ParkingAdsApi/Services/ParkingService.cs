using ParkingAdsApi.ApiClients.ParkingClient;

namespace ParkingAdsApi.Services;

public class ParkingService
{
    private ParkingClient _parkingClient;

    public ParkingService(HttpClient httpClient, IConfiguration configuration)
    {
        var parkingServiceUrl = configuration["ParkingServiceUrl"];
        _parkingClient = new ParkingClient(parkingServiceUrl, httpClient);
    }

    public async Task<IEnumerable<ParkingSpot>> GetParkingSpots()
    {
        try
        {
            return await _parkingClient.ParkingSpotAsync();
        }
        catch
        {
            return new List<ParkingSpot>();
        }
    }
}