using MonthlyPremiumCalculator.Core.Interfaces;
using MonthlyPremiumCalculator.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddScoped<IOccupationRepository,OccupationRepository>();

builder.Services.AddScoped<IPremiumService,PremiumService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapControllers();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseHttpsRedirection();

app.Run();
