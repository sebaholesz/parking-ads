using ParkingService.Application;
using ParkingService.Domain;
using ParkingService.ParkingSpotApi.Responses;

namespace ParkingService.Infrastructure;

public class Mapper : IMapper
{

    public ParkingSpot MapParkingSpotResponseToParkingSpot(ParkingSpotResponse parkingSpotResponse)
    {
        return new ParkingSpot
        {
            Created = DateTime.Parse(parkingSpotResponse.Created),
            Name = parkingSpotResponse.Name,
            Coordinates = parkingSpotResponse.Coordinates,
            Capacity = int.Parse(parkingSpotResponse.Capacity),
            CurrentlyInUse = int.Parse(parkingSpotResponse.CurrentlyInUse)
        };
    }
}
