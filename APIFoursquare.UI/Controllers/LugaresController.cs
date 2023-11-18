using APIFoursquare.Application.Models;
using APIFoursquare.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIFoursquare.UI.Controllers
{
    public class LugaresController : Controller
    {
        private readonly ILugarService _lugarService;

        public LugaresController(ILugarService lugarService)
        {
            _lugarService = lugarService;
        }

        public IActionResult Favoritos()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerFavoritos()
        {
            try
            {
                var resultado = await _lugarService.ObtenerLugaresFavoritosAsync();

                return Ok(resultado);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GuardarFavorito(LugarModel modelo)
        {
            try
            {
                var resultado = await _lugarService.GuardarAsync(modelo);

                return Ok(resultado);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
