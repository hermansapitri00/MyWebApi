namespace MyWebApi.Endpoints;

public static class CountryEndpoint
{
    public static void MapCountries(this WebApplication app)
    {
        var countriesEndpoint = app.MapGroup("/countries");
        {
            countriesEndpoint.MapGet("", GetCountries)
            .WithName("GetCountries")
            .WithOpenApi();
        }
    }

    private static IEnumerable<Country> GetCountries()
    {
        List<Country> countries =
        [
            new("USA", "United States of America"),
            new("CAN", "Canada"),
            new("MEX", "Mexico")
        ];

        return countries;
    }

    record Country(string Code, string Name);
}