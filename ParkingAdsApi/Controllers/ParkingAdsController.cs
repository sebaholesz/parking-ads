using Microsoft.AspNetCore.Mvc;

namespace ParkingAdsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ParkingAdsController : Controller
{
    public string Get()
    {
        return "Hello world";
    }
}