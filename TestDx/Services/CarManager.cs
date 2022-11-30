using Microsoft.EntityFrameworkCore;
using TestDx.Dto;
using TestDx.Entities;
using TestDx.EntityFramework;

namespace TestDx.Services;

public class CarManager : ICarService
{
    private readonly TestDxDbContext _dbContext;

    public CarManager(TestDxDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddCar(Car car)
    {
        _dbContext.Cars.Add(car);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<CarDto>> GetCarsByColor(int colorId)
    {
        var result = await _dbContext.Cars
            .Include(x => x.Color)
            .Where(x => x.ColorId == colorId)
            .Select(x => new CarDto
            {
                Name = x.Name,
                ColorName = x.Color.Name
            }).ToListAsync();

        return result;
    }
}