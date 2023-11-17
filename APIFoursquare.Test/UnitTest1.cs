using APIFoursquare.Services.Interface;

namespace APIFoursquare.Test
{
    public class UnitTest1
    {
        private readonly IFoursquareService foursquareService;

        public UnitTest1()
        {
            foursquareService = Helper.GetRequiredService<IFoursquareService>() ?? throw new ArgumentException(nameof(IFoursquareService));
        }

        [Fact]
        public async Task Test1Async()
        {
            var lugares = await foursquareService.BuscarLugares(13032, (decimal)19.04334, (decimal)-98.20193);

            Assert.True(lugares.Count > 0, "Se encontraron lugares");
        }
    }
}