using JoCleaners.Core;
using JoCleaners.Core.Entities;
using JoCleaners.Core.Entities.Users.Dtos;
using JoCleaners.Core.Intrface;
using JoCleaners.Presistance;
using JoCleaners.Presistance.SQLDataBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JoCleaners.Services.Users
{
    public class ApplicationUserManager : IUserManager
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public ApplicationUserManager(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public Task AddEntityAsyinc(UserDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteEntityAsync(UserDto entity)
        {
            if (entity.Id == Guid.Empty)
                throw new Exception("user is null");
            var user = new User
            {
                Id = entity.Id,
            };
            await _unitOfWork._UserRepository.DeleteEntityAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task<User> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDto>> GetEntitiesAsync()
        {
            var users = await _unitOfWork._UserRepository.GetEntitiesAsync();
            return users.Select(x => new UserDto
            {
                Email = x.Email,
                Id = x.Id,
                Name = x.UserName
            }).ToList();
        }

        public async Task<UserDto> GetEntityAsync(Guid Id)
        {
            var user = await _unitOfWork._UserRepository.GetEntityAsync(Id);
            return new UserDto
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.UserName
            };

        }

      
        public async Task UpdateEntityAsync(UserDto entity)
        {
            var user = new User
            {
                Id = entity.Id,
                Email = entity.Email,
                UserName = entity.Name,
            };
            await _unitOfWork._UserRepository.UpdateEntityAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
