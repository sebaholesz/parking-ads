using ParkingService.Domain;

namespace ParkingService.Application;

public interface IParkingSpotProvider
{
    Task<IEnumerable<ParkingSpot>> GetParkingSpotsAsync();
}
