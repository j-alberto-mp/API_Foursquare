using Newtonsoft.Json;

namespace APIFoursquare.Application.Views
{
    public class FoursquareResponse
    {
        public List<LugarView> Results { get; set; }
    }

    public class LugarView
    {
        [JsonProperty("fsq_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Nombre { get; set; }

        [JsonProperty("geocodes")]
        public Geocodes Geocodes { get; set; }

        [JsonProperty("location")]
        public Location Direccion { get; set; }

        public decimal Puntuacion { get; set; }

        public List<Fotos> FotosLugar { get; set; }
    }

    public class Geocodes
    {
        [JsonProperty("main")]
        public MainGeocode Main { get; set; }
    }

    public class MainGeocode
    {
        [JsonProperty("latitude")]
        public decimal Latitud { get; set; }

        [JsonProperty("longitude")]
        public decimal Longitud { get; set; }
    }

    public class Location
    {
        [JsonProperty("formatted_address")]
        public string Calle { get; set; }
    }

    public class Rating
    {
        [JsonProperty("rating")]
        public decimal Puntuacion { get; set; }
    }

    public class Fotos
    {
        [JsonProperty("prefix")]
        public string UrlBase { get; set; }

        [JsonProperty("suffix")]
        public string Archivo { get; set; }
    }
}