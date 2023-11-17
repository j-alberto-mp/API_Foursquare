using APIFoursquare.Application;
using APIFoursquare.Services.Interface;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFoursquare.Services.Implementation
{
    public class FoursquareService : IFoursquareService
    {
        public async Task<List<LugarViewModel>> BuscarLugares(int categoria, decimal latitud, decimal longitud)
        {
            try
            {
                List<LugarViewModel> lugares = new();

                RestClientOptions options = new($"https://api.foursquare.com/v3/places/search?ll={latitud}%2C{longitud}&categories={categoria}&fields=fsq_id%2Cgeocodes%2Clocation%2Cname&limit=20");
                
                string contenidoLugares = await CrearPeticionAsync(options);

                if (!string.IsNullOrEmpty(contenidoLugares))
                {
                    FoursquareResponse respuesta = JsonConvert.DeserializeObject<FoursquareResponse>(contenidoLugares) ?? new();

                    lugares = respuesta.Results;

                    foreach (LugarViewModel l in lugares)
                    {
                        RestClientOptions opcionesDetalle = new($"https://api.foursquare.com/v3/places/{l.Id}?fields=rating");

                        string contenidoDetalle = await CrearPeticionAsync(opcionesDetalle);

                        RatingViewModel rating = JsonConvert.DeserializeObject<RatingViewModel>(contenidoDetalle) ?? new();

                        l.Puntuacion = rating.Puntuacion;
                        l.FotosLugar = new();

                        RestClientOptions opcionesFotos = new($"https://api.foursquare.com/v3/places/{l.Id}/photos?limit=5&sort=NEWEST&classifications=indoor");

                        string contenidoFotos = await CrearPeticionAsync(opcionesFotos);

                        l.FotosLugar = JsonConvert.DeserializeObject<List<FotosViewModel>>(contenidoFotos) ?? new();
                    }
                }

                return lugares;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<string> CrearPeticionAsync(RestClientOptions options)
        {
            using RestClient client = new(options);
            RestRequest request = new("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", "fsq3IlTON2qs+3LS3P/t3Lp3Yf6ucNYG725FEIlNMPGwW2Y=");

            RestResponse response = await client.GetAsync(request);

            return response.Content ?? "";
        }
    }
}
