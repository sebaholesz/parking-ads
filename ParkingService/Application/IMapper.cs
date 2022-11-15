using ParkingService.Domain.Models;
using ParkingService.ParkingSpotApi.Responses;

namespace ParkingService.Application;

public interface IMapper
{
    ParkingSpot MapParkingSpotResponseToParkingSpot(ParkingSpotResponse parkingSpotResponse);
}
