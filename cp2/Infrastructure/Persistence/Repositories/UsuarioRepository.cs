using cp2.Domain.Entity;
using cp2.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace cp2.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAll() => await _context.Usuarios.Include(u => u.Motos).ToListAsync();
        public async Task<Usuario> GetById(Guid id) => await _context.Usuarios.Include(u => u.Motos).FirstOrDefaultAsync(u => u.Id == id);
        public async Task Add(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var usuario = await GetById(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
