using ParkingService.Domain.Models;

namespace ParkingService.Application;

public interface IParkingSpotProvider
{
    Task<IEnumerable<ParkingSpot>> GetParkingSpotsAsync();
}
