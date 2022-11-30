using Microsoft.EntityFrameworkCore;
using TestDx.EntityFramework;
using TestDx.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<TestDxDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("TestDxDb"));
});

// Dependency Injection Lifetime
builder.Services.AddScoped<ICarService, CarManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();