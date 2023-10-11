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
    public class LocationDataService : IDataService<Location>
    {
        private readonly FMSDbContext _context;
        public LocationDataService(FMSDbContext context)
        {
            _context = context;
        }
        public async Task<Location> Create(Location entity)
        {
            
            var addedEntity = _context.Locations.Add(entity).Entity;
            await _context.SaveChangesAsync();
            return addedEntity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Locations.FindAsync(id);
            if (entity != null)
            {
                _context.Locations.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Location> Get(int id)
        {
            return await _context.Locations.FindAsync(id);
        }

        public async Task<IEnumerable<Location>> GetAll()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<Location> Update(int id, Location entity)
        {
            var existingEntity = await _context.Locations.FindAsync(id);
            if (existingEntity != null)
            {
                
                existingEntity.Name = entity.Name;
                existingEntity.PositionX = entity.PositionX;
                existingEntity.PositionY = entity.PositionY;
                existingEntity.PositionR = entity.PositionR;
                existingEntity.Type = entity.Type;
                await _context.SaveChangesAsync();
            }
            return existingEntity;
        }
    }
}
