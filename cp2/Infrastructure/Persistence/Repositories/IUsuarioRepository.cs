using cp2.Domain.Entity;

namespace cp2.Infrastructure.Persistence.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario> GetById(Guid id);
        Task Add(Usuario usuario);
        Task Update(Usuario usuario);
        Task Delete(Guid id);
    }
}
