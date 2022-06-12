using Newtonsoft.Json;

namespace AdapterPattern;

public class InternetThermometer
{
    public static readonly HttpClient Client = new();

    public InternetThermometer() =>
        Client.BaseAddress = new Uri("http://api.openweathermap.org/");

    public string Themperature =>
        JsonConvert.DeserializeObject<dynamic>(Client
            .GetAsync("data/2.5/weather?q=Rzeszow&appid=cad76f95258d484b8b7ef48ac4695f8c")
            .Result
            .Content
            .ReadAsStringAsync()
            .Result)!.main.temp;
}