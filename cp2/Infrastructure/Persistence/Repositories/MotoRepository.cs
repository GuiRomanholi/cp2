using cp2.Domain.Entity;
using cp2.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace cp2.Infrastructure.Persistence.Repositories
{
    public class MotoRepository : IMotoRepository
    {
        private readonly AppDbContext _context;

        public MotoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Moto>> GetAll() => await _context.Motos.Include(m => m.Usuario).ToListAsync();

        public async Task<Moto> GetById(Guid id) => await _context.Motos.Include(m => m.Usuario).FirstOrDefaultAsync(m => m.Id == id);

        public async Task Add(Moto moto)
        {
            await _context.Motos.AddAsync(moto);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Moto moto)
        {
            _context.Motos.Update(moto);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var moto = await GetById(id);
            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();
        }
    }
}
