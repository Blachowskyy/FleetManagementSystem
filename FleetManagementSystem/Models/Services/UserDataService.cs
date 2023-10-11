using FleetManagementSystem.Models.Services.Interfaces;
using FleetManagementSystem.Services.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Models.Services
{
    public class UserDataService : IDataService<User>
    {
        private readonly FMSDbContext _context;
        private User _currentUser;
        public UserDataService(FMSDbContext context, User currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }
        public async Task<User> Create(User entity)
        {
            var addedEntity = _context.Users.Add(entity).Entity;
            await _context.SaveChangesAsync();
            return addedEntity;
        }

        public async Task<bool> Delete(int id)
        {
            var  entity = await _context.Users.FindAsync(id);
            if (entity != null)
            {
                _context.Users.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Update(int id, User entity)
        {
            var existingentity = await _context.Users.FindAsync(id);
            if (existingentity != null)
            {
                existingentity.Id = id;
                existingentity.Username = entity.Username;
                existingentity.Password = entity.Password;
                existingentity.SuperUser = entity.SuperUser;
                existingentity.IsLogged = entity.IsLogged;
                existingentity.Installator = entity.Installator;
                await _context.SaveChangesAsync();
            }
            return existingentity;
        }
    }
}
