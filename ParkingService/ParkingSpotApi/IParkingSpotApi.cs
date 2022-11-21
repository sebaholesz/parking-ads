using ParkingService.ParkingSpotApi.Responses;
using Refit;

namespace ParkingService.ParkingSpotApi;

public interface IParkingSpotApi
{
    /// <summary>
    /// Method that returns all free parking spots from Brian's API. (Who makes a REST API in PHP???)
    /// </summary>
    /// <returns></returns>
    [Get("/service.php")]
    Task<IEnumerable<ParkingSpotResponse>> GetParkingSpotsAsync();
}
