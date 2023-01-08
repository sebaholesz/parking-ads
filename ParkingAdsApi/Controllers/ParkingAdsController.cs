using Microsoft.AspNetCore.Mvc;
using ParkingAdsApi.ApiClients.AdClient;
using ParkingAdsApi.ApiClients.ParkingClient;
using ParkingAdsApi.Models;
using ParkingAdsApi.Services;

namespace ParkingAdsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ParkingAdsController : Controller
{
    private readonly AdService _adService;
    private readonly ParkingService _parkingService;

    public ParkingAdsController(AdService adService, ParkingService parkingService)
    {
        _adService = adService;
        _parkingService = parkingService;
    }
    
    [HttpGet]
    public async Task<ParkingResponse> Get()
    {
        var ads = await _adService.GetAds(Random.Shared.Next(1, 5));
        var parkingSpaces = await _parkingService.GetParkingSpots();
        return new ParkingResponse()
        {
            Ads = ads,
            ParkingSpots = parkingSpaces
        };
    }
}