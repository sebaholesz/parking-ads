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
            Latitude = parkingSpotResponse.Geometry.Coordinates[0],
            Longitude = parkingSpotResponse.Geometry.Coordinates[1],
            StreetName = parkingSpotResponse.Properties.StreetName,
            StreetNumber = parkingSpotResponse.Properties.StreetNumber,
            Details = parkingSpotResponse.Properties.Details,
            City = "Aarhus",
            Country = "Denmark",
            ZipCode = "8000",
            Created = DateTime.Parse(parkingSpotResponse.Properties.Created),
            LastUpdated = DateTime.Parse(parkingSpotResponse.Properties.LastUpdated),
        };
    }
}
