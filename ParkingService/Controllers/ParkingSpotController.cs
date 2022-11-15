using Microsoft.AspNetCore.Mvc;
using ParkingService.Application;
using ParkingService.Domain;

namespace ParkingService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParkingSpotController : ControllerBase
{
    private readonly ICacheService _cacheService;
    private readonly IParkingSpotProvider _parkingSpotProvider;

    public ParkingSpotController(ICacheService cacheService, IParkingSpotProvider parkingSpotProvider)
    {
        this._cacheService = cacheService;
        this._parkingSpotProvider = parkingSpotProvider;
    }

    /// <summary>
    /// TODO: Cleaner way of caching.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IEnumerable<ParkingSpot>> Get()
    {
        var cachedParkingSpots = this._cacheService.GetData<IEnumerable<ParkingSpot>>("parkingSpots");
        if (cachedParkingSpots is not null)
            return cachedParkingSpots;

        IEnumerable<ParkingSpot> parkingSpots = (await this._parkingSpotProvider.GetParkingSpotsAsync()).ToList();
        DateTimeOffset cacheExpirationTime = DateTimeOffset.Now.AddHours(1);
        this._cacheService.SetData("parkingSpots", parkingSpots, cacheExpirationTime);

        return parkingSpots;
    }
}
