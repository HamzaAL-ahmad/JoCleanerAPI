using JoCleaners.Core.Entities;
using JoCleaners.Core.Entities.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoCleaners.Core.Intrface
{
    public interface IUserManager:IRepository<UserDto> 
    {
        Task<User> GetByEmailAsync(string email);
    }

}
