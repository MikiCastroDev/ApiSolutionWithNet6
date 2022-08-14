namespace Api.CrossCutting.Contracts.Objects
{
    public class WeatherDTO
    {
        public RequestDTO request { get; set; }
        public LocationDTO location { get; set; }
        public CurrentWeatherDTO current { get; set; }
    }
}
