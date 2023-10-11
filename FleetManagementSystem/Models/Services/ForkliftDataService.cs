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
    public class ForkliftDataService : IDataService<Forklift>
    {
        private readonly FMSDbContext _context;
        public ForkliftDataService(FMSDbContext context)
        {
            _context = context;
        }
        public async Task<Forklift> Create(Forklift entity)
        {
            var addedEntity = _context.Forklifts.Add(entity).Entity;
            await _context.SaveChangesAsync();
            return addedEntity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Forklifts.FindAsync(id);
            if (entity != null) 
            {
                _context.Forklifts.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Forklift> Get(int id)
        {
            return await _context.Forklifts.FindAsync(id);
        }

        public async Task<IEnumerable<Forklift>> GetAll()
        {
            return await _context.Forklifts.ToListAsync();
        }

        public async Task<Forklift> Update(int id, Forklift entity)
        {
            var existingEntity = await _context.Forklifts.FindAsync(id);
            if (existingEntity != null)
            {
                existingEntity = entity;
                await _context.SaveChangesAsync();
            }
            return existingEntity;
        }
    }
}
