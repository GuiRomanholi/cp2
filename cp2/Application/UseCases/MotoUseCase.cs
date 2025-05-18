using cp2.Application.DTOs.Request;
using cp2.Application.DTOs.Response;
using cp2.Domain.Entity;
using cp2.Infrastructure.Persistence.Repositories;

namespace cp2.Application.UseCases
{
    public class MotoUseCase
    {
        private readonly IMotoRepository _repository;

        public MotoUseCase(IMotoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MotoResponse>> ListarTodos()
        {
            var motos = await _repository.GetAll();

            var response = motos.Select(moto => new MotoResponse
            {
                Id = moto.Id,
                Modelo = moto.Modelo,
                Placa = moto.Placa
            });

            return response;
        }

        public async Task<MotoResponse> Criar(MotoRequest request)
        {
            var moto = new Moto(request.Modelo, request.Placa, request.UsuarioId);
            await _repository.Add(moto);

            var response = new MotoResponse
            {
                Id = moto.Id,
                Modelo = moto.Modelo,
                Placa = moto.Placa
            };

            return response;
        }

        public async Task Atualizar(Guid id, MotoRequest request)
        {
            var motoExistente = await _repository.GetById(id);
            if (motoExistente == null) throw new KeyNotFoundException("Moto não encontrada");

            motoExistente.SetModelo(request.Modelo);
            motoExistente.SetPlaca(request.Placa);
            await _repository.Update(motoExistente);
        }

        public async Task Excluir(Guid id)
        {
            await _repository.Delete(id);
        }

        public async Task<MotoResponse> BuscarPorId(Guid id)
        {
            var moto = await _repository.GetById(id);
            if (moto == null) throw new KeyNotFoundException("Moto não encontrada");

            return new MotoResponse
            {
                Id = moto.Id,
                Modelo = moto.Modelo,
                Placa = moto.Placa
            };
        }
    }
}
