using JoCleaners.Core;
using JoCleaners.Core.Entities;
using JoCleaners.Presistance.SQLDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoCleaners.Presistance
{
    public class UnitOfWork: IUnitOfWork
    {
        public IRepository<User> _UserRepository { get; }


        private readonly ApplicationDbContext _context;


        public UnitOfWork(ApplicationDbContext context)
        {
            
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _UserRepository = new Repository<User>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges(); 
        }

        public async Task SaveChangesAsync() 
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
