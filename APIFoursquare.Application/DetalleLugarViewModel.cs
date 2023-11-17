using Newtonsoft.Json;

namespace APIFoursquare.Application
{
    public class DetalleLugarViewModel
    {
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