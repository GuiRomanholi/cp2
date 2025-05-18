using cp2.Application.DTOs.Request;
using cp2.Application.DTOs.Response;
using cp2.Domain.Entity;
using cp2.Infrastructure.Persistence.Repositories;

namespace cp2.Application.UseCases
{
    public class UsuarioUseCase
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioUseCase(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UsuarioResponse>> ListarTodos()
        {
            var usuarios = await _repository.GetAll();

            var response = usuarios.Select(usuario => new UsuarioResponse
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Motos = usuario.Motos?.Select(moto => new MotoResponse
                {
                    Id = moto.Id,
                    Modelo = moto.Modelo,
                    Placa = moto.Placa
                }).ToList()
            });

            return response;
        }

        public async Task<UsuarioResponse> Criar(UsuarioRequest dto)
        {
            var usuario = new Usuario(dto.Nome, dto.Email);
            await _repository.Add(usuario);

            return new UsuarioResponse
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Motos = new List<MotoResponse>()
            };
        }

        public async Task<UsuarioResponse> BuscarPorId(Guid id)
        {
            var usuario = await _repository.GetById(id);
            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado");

            return new UsuarioResponse
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Motos = usuario.Motos?.Select(moto => new MotoResponse
                {
                    Id = moto.Id,
                    Modelo = moto.Modelo,
                    Placa = moto.Placa
                }).ToList()
            };
        }

        public async Task Atualizar(Guid id, UsuarioRequest dto)
        {
            var usuario = await _repository.GetById(id);
            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado");

            usuario.SetNome(dto.Nome);
            usuario.SetEmail(dto.Email);

            await _repository.Update(usuario);
        }

        public async Task Excluir(Guid id)
        {
            var usuario = await _repository.GetById(id);
            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado");

            await _repository.Delete(id);
        }
    }
}
