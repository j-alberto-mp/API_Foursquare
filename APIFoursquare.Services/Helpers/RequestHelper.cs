using RestSharp;

namespace APIFoursquare.Services.Helpers
{
    internal static class RequestHelper
    {
        public static async Task<string> CrearPeticionAsync(RestClientOptions options)
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
