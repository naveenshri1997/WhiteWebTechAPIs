using Microsoft.EntityFrameworkCore;
using WhiteWebTech.API.DataAccess;
using WhiteWebTech.API.Services.IServices;

namespace WhiteWebTech.API.Services
{
    public class GenericServices<T> : IGenericServices<T>
    where T : class
    {
        private readonly WhiteDbContext _context;
        protected DbSet<T> _dbSet;
        public GenericServices(WhiteDbContext dbContext)
        {
            this._context = dbContext;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> Create(T entity)
        {
            _dbSet.Attach(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetAll() => await _dbSet.ToListAsync();


        public async Task<T> GetById(int id) => await _dbSet.FindAsync(id);


        public async Task Update(int id, T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
