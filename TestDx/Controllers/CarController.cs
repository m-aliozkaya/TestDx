using Microsoft.AspNetCore.Mvc;
using TestDx.Dto;
using TestDx.Services;

namespace TestDx.Controllers;

[ApiController]
[Route("api/[Controller]/[Action]")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet(Name = "GetCarsByColorId/{colorId}")]
    public async Task<IEnumerable<CarDto>> GetCarsByColorId(int colorId)
    {
        var result = await _carService.GetCarsByColor(colorId);
        return result;
    }
}