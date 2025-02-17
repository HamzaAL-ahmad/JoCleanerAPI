using JoCleaners.Core;
using JoCleaners.Presistance.SQLDataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace JoCleaners.Presistance
{
    public class Repository<Entity> : IRepository<Entity> where Entity : class, IEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Entity> _entities;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entities = _context.Set<Entity>();
        }

        public async Task AddEntityAsyinc(Entity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(Entity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Entity>> GetEntitiesAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<Entity> GetEntityAsync(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                throw new Exception("Entity not found!");
            }
            return await _entities.SingleOrDefaultAsync(e => e.Id == Id);
        }

        public async Task UpdateEntityAsync(Entity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

    }
}
