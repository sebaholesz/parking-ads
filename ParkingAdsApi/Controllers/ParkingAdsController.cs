using Microsoft.AspNetCore.Mvc;
using ParkingAdsApi.ApiClients.AdClient;
using ParkingAdsApi.ApiClients.ParkingClient;
using ParkingAdsApi.Models;

namespace ParkingAdsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ParkingAdsController : Controller
{
    private AdClient _adClient;
    private ParkingClient _parkingClient;
    
    public ParkingAdsController(HttpClient httpClient, IConfiguration configuration)
    {
        var adServiceUrl = configuration["AdServiceUrl"];
        var parkingServiceUrl = configuration["ParkingServiceUrl"];

        _adClient = new AdClient(adServiceUrl, httpClient);
        _parkingClient = new ParkingClient(parkingServiceUrl, httpClient);
    }
    
    [HttpGet]
    public async Task<ParkingResponse> Get()
    {
        var ads = await _adClient.GetAdsAsync(Random.Shared.Next(1, 5));
        var parkingSpaces = await _parkingClient.ParkingSpotAsync();
        return new ParkingResponse()
        {
            Ads = ads,
            ParkingSpots = parkingSpaces
        };
    }
}