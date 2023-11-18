using APIFoursquare.Application.Views;
using APIFoursquare.Data;
using APIFoursquare.Repository.Interface;
using APIFoursquare.Services.Interface;
using AutoMapper;

namespace APIFoursquare.Services.Implementation
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IRepository<Categoria> _repository;
        private readonly IMapper _mapper;

        public CategoriaService(IRepository<Categoria> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoriaView>> ObtenerListaAsync()
        {
            try
            {
                List<Categoria> categorias = await _repository.GetListAsync();

                return _mapper.Map<List<CategoriaView>>(categorias);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
