using APIFoursquare.Application.Models;
using APIFoursquare.Application.Views;
using APIFoursquare.Data;
using APIFoursquare.Repository.Interface;
using APIFoursquare.Services.Helpers;
using APIFoursquare.Services.Interface;
using AutoMapper;
using Newtonsoft.Json;
using RestSharp;

namespace APIFoursquare.Services.Implementation
{
    public class LugarService : ILugarService
    {   
        private readonly IMapper _mapper;
        private readonly IRepository<Lugar> _lugarRepository;
        private readonly IRepository<LugarFavorito> _lugarFavoritoRepository;
        private readonly IRepository<Categoria> _categoriaRepository;

        public LugarService(IMapper mapper, IRepository<Lugar> lugarRepository, IRepository<LugarFavorito> lugarFavoritoRepository, IRepository<Categoria> categoriaRepository)
        {
            _mapper = mapper;
            _lugarRepository = lugarRepository;
            _lugarFavoritoRepository = lugarFavoritoRepository;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<bool> GuardarAsync(LugarModel modelo)
        {
            try
            {
                Lugar lugar = await _lugarRepository.GetAsync(q => q.Id == modelo.IdLugar);

                // Validar si aún no está registrado, para evitar información duplicada
                if (lugar == null)
                {
                    lugar = _mapper.Map<Lugar>(modelo);

                    lugar = await _lugarRepository.InsertAsync(lugar);

                    LugarFavorito lugarFavorito = new()
                    {
                        LugarId = lugar.Id,
                        UsuarioId = 1
                    };

                    lugarFavorito = await _lugarFavoritoRepository.InsertAsync(lugarFavorito);

                    return true;
                }
                else
                {
                    throw new ApplicationException("El lugar ya se guardó como favorito anteriormente");
                }
            }
            catch (ApplicationException applicationException)
            {
                throw applicationException;
            }
            catch (Exception)
            {
                throw new Exception("Ocurrió un error al realizar el registro");
            }
        }

        public async Task<List<CategoriaLugarView>> ObtenerLugaresFavoritosAsync()
        {
            try
            {
                List<CategoriaLugarView> categoriasLugares = new();
                List<LugarFavorito> lugaresFavoritos = await _lugarFavoritoRepository.GetListAsync(q => q.UsuarioId == 1);

                foreach (LugarFavorito favorito in lugaresFavoritos)
                {
                    Lugar lugar = await _lugarRepository.GetAsync(q => q.Id == favorito.LugarId);
                    CategoriaLugarView categoriaLugar = categoriasLugares.FirstOrDefault(q => q.IdCategoria == lugar.CategoriaId);

                    if(categoriaLugar == null)
                    {
                        Categoria? categoria = await _categoriaRepository.GetAsync(q => q.Id == lugar.CategoriaId);
                        categoriaLugar = new()
                        {
                            IdCategoria = categoria.Id,
                            Categoria = categoria.Nombre,
                            Favoritos = new()
                        };

                        categoriasLugares.Add(categoriaLugar);
                    }

                    LugarFavoritoView lugarFavorito = _mapper.Map<LugarFavoritoView>(lugar);

                    RestClientOptions opcionesFotos = new($"https://api.foursquare.com/v3/places/{lugar.Id}/photos?limit=5&sort=NEWEST");

                    string contenidoFotos = await RequestHelper.CrearPeticionAsync(opcionesFotos);

                    lugarFavorito.FotosLugar = JsonConvert.DeserializeObject<List<Fotos>>(contenidoFotos) ?? new();

                    categoriaLugar.Favoritos.Add(lugarFavorito);
                }

                return categoriasLugares;
            }
            catch (Exception)
            {
                throw new Exception("Ocurrió un error al obtener los registros");
            }
        }
    }
}