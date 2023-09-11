using HttpClientDelegatingHandlers;
using HttpClientDelegatingHandlers.Controllers;
using HttpClientDelegatingHandlers.DelegateHandlers;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

builder.Services.Configure<WeatherApiConfig>(
    builder.Configuration.GetSection(nameof(WeatherApiConfig)));

builder.Services.AddScoped<WeatherApiAuthHandler>();
builder.Services.AddScoped<CachingHandler>();
builder.Services.AddScoped<LoggingHandler>();
builder.Services.AddScoped<ResilientHandler>();
builder.Services.AddHttpClient<IWeatherService, WeatherService>(client =>
    {
        var weatherOptions = builder.Configuration.GetSection(nameof(WeatherApiConfig)).Get<WeatherApiConfig>();
        client.BaseAddress = new Uri(weatherOptions!.BaseAddress);
    })
    .AddHttpMessageHandler<WeatherApiAuthHandler>()
    .AddHttpMessageHandler<ResilientHandler>()
    .AddHttpMessageHandler<LoggingHandler>()
    .AddHttpMessageHandler<CachingHandler>();

// Add services to the container.
builder.Services.AddControllers();

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