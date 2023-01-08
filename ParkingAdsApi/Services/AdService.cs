using ParkingAdsApi.ApiClients.AdClient;

namespace ParkingAdsApi.Services;

public class AdService
{
    private AdClient _adClient;

    public AdService(HttpClient httpClient, IConfiguration configuration)
    {
        var adServiceUrl = configuration["AdServiceUrl"];
        _adClient = new AdClient(adServiceUrl, httpClient);
    }

    public async Task<IEnumerable<string>> GetAds(int count)
    {
        try
        {
            return await _adClient.GetAdsAsync(count);
        }
        catch
        {
            return new List<string>();
        }
    }
}