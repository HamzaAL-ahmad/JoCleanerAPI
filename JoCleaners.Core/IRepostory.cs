using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoCleaners.Core
{
    public interface IRepository<Entity> where Entity : class, IEntity
    {
        public Task<Entity> GetEntityAsync(Guid Id);
        public Task AddEntityAsyinc(Entity Id);
        public  Task<List<Entity>> GetEntitiesAsync();
        public Task UpdateEntityAsync(Entity entity);
        public Task DeleteEntityAsync(Entity entity);
    }
}
