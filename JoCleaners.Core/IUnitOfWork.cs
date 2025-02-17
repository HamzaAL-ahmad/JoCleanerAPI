using JoCleaners.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoCleaners.Core
{
    public interface IUnitOfWork:IDisposable
    {
        public IRepository<User> _UserRepository { get; }
        public void SaveChanges();
        Task SaveChangesAsync();

    }
}
