namespace ParkingService.Domain;

public class ParkingSpot
{
    public DateTime Created { get; init; }
    public string Name { get; init; }
    public string Coordinates { get; init; }
    public int Capacity { get; init; }
    public int CurrentlyInUse { get; init; }
}
