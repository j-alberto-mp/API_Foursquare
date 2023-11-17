using APIFoursquare.Services.Interface;
using APIFoursquare.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace APIFoursquare.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IFoursquareService _foursquareService;

        public HomeController(ICategoriaService categoriaService, IFoursquareService foursquareService)
        {
            _categoriaService = categoriaService;
            _foursquareService = foursquareService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerCategorias()
        {
            try
            {
                var resultado = await _categoriaService.ObtenerListaAsync();

                return Ok(resultado);
            }
            catch (Exception)
            {
                return BadRequest("Ocurrió un error al obtener las categorías");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerLugares(int categoria, decimal latitud, decimal longitud)
        {
            try
            {
                var resultado = await _foursquareService.BuscarLugares(categoria, latitud, longitud);

                return Ok(resultado);
            }
            catch (Exception)
            {
                return BadRequest("Ocurrió un error al obtener los lugares");
            }
        }
    }
}
