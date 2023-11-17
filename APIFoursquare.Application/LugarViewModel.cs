using Newtonsoft.Json;

namespace APIFoursquare.Application
{
    public class FoursquareResponse
    {
        public List<LugarViewModel> Results { get; set; }
    }

    public class LugarViewModel
    {
        [JsonProperty("fsq_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Nombre { get; set; }

        [JsonProperty("geocodes.main.latitude")]
        public decimal Latitude { get; set; }

        [JsonProperty("geocodes.main.longitude")]
        public decimal Longitude { get; set; }

        [JsonProperty("location.formatted_address")]
        public string Direccion { get; set; }

        public DetalleLugarViewModel DetalleLugar { get; set; }
    }
}