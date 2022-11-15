namespace ParkingService.Domain;

public class ParkingSpot
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string StreetName { get; set; }
    public string StreetNumber { get; set; }
    public string Details { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastUpdated { get; set; }
}
