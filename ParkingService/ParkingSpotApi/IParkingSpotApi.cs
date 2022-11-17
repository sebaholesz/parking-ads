using ParkingService.ParkingSpotApi.Responses;
using Refit;

namespace ParkingService.ParkingSpotApi;

public interface IParkingSpotApi
{
    /// <summary>
    /// Method that returns all free parking spots.
    /// TODO: Currently only returns parking spots from Aarhus.
    /// </summary>
    /// <returns></returns>
    [Get("/spatialmap?page=get_geojson_opendata&datasource=delebil")]
    Task<ParkingSpotApiResponse> GetParkingSpotsAsync();
}
