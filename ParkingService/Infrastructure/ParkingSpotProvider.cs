using ParkingService.Application;
using ParkingService.Domain;
using ParkingService.ParkingSpotApi;
using ParkingService.ParkingSpotApi.Responses;

namespace ParkingService.Infrastructure;

public class ParkingSpotProvider : IParkingSpotProvider
{
    private readonly IParkingSpotApi _parkingSpotApi;
    private readonly IMapper _mapper;
    
    public ParkingSpotProvider(IParkingSpotApi parkingSpotApi, IMapper mapper)
    {
        this._parkingSpotApi = parkingSpotApi;
        this._mapper = mapper;
    }

    public async Task<IEnumerable<ParkingSpot>> GetParkingSpotsAsync()
    {
        ParkingSpotApiResponse parkingSpots = await this._parkingSpotApi.GetParkingSpotsAsync();
        return parkingSpots.ParkingSpots.Select(this._mapper.MapParkingSpotResponseToParkingSpot);
    }
}
