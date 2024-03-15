namespace MyWebApi.Endpoints;

public static class WeatherEndpoint
{
    private static string[] _summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public static void MapWeathers(this WebApplication app)
    {

       var weathersEndpoint = app.MapGroup("/weathers");
       {
        weathersEndpoint.MapGet("", GetWeathers)
        .WithName("GetWeatherForecast")
        .WithOpenApi();
       }

    }

    private static WeatherForecast[] GetWeathers()
    {
        var forecast =  Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                _summaries[Random.Shared.Next(_summaries.Length)]
            ))
            .ToArray();
        return forecast;
    }

    record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}