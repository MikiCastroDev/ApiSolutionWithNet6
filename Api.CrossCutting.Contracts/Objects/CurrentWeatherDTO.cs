namespace Api.CrossCutting.Contracts.Objects
{
    public class CurrentWeatherDTO
    {
        public string observation_time { get; set; }
        public string temperature { get; set; }
        public int humidity { get; set; }
    }
}
