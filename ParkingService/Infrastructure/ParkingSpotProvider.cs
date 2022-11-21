using ParkingService.Application;
using ParkingService.Domain;
using ParkingService.ParkingSpotApi;
using ParkingService.ParkingSpotApi.Responses;
using Polly;
using Refit;

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
        // TODO: Messy, refactor
        IEnumerable<ParkingSpotResponse> parkingSpots = await Policy
            .Handle<ApiException>(ex => ex.Message.Any())
            .RetryAsync(20, (exception, retryCount) => Console.WriteLine("Retrying to get API parking data..."))
            .ExecuteAsync(async () => await this._parkingSpotApi.GetParkingSpotsAsync());
        return parkingSpots.Select(this._mapper.MapParkingSpotResponseToParkingSpot);
    }
}
