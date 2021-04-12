using Microsoft.EntityFrameworkCore;
using Project.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Data.Repositories
{
    public class BaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {   
            _context = context;
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}
