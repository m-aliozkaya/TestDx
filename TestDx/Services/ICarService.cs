using TestDx.Dto;
using TestDx.Entities;

namespace TestDx.Services;

public interface ICarService
{
    Task AddCar(Car car);
    Task<List<CarDto>> GetCarsByColor(int colorId);
}