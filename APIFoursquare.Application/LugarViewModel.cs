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

        public decimal Puntuacion { get; set; }

        public List<FotosViewModel> FotosLugar { get; set; }
    }

    public class RatingViewModel
    {
        [JsonProperty("rating")]
        public decimal Puntuacion { get; set; }
    }

    public class FotosViewModel
    {
        [JsonProperty("prefix")]
        public string UrlBase { get; set; }

        [JsonProperty("suffix")]
        public string Archivo { get; set; }
    }
}