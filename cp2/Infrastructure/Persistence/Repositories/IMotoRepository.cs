using cp2.Domain.Entity;

namespace cp2.Infrastructure.Persistence.Repositories
{
    public interface IMotoRepository
    {
        Task<IEnumerable<Moto>> GetAll();
        Task<Moto> GetById(Guid id);
        Task Add(Moto moto);
        Task Update(Moto moto);
        Task Delete(Guid id);
    }
}
