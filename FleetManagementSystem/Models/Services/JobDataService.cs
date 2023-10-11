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
    public class JobDataService : IDataService<Job>
    {
        private readonly FMSDbContext _context;
        public JobDataService(FMSDbContext context)
        {
            _context = context;
        }

        public async Task<Job> Create(Job entity)
        {
            var addedEntity = _context.Jobs.Add(entity).Entity;
            await _context.SaveChangesAsync();
            return addedEntity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Jobs.FindAsync(id);
            if (entity != null)
            {
                _context.Jobs.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Job> Get(int id)
        {
            return await _context.Jobs.FindAsync(id);
        }

        public async Task<IEnumerable<Job>> GetAll()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<Job> Update(int id, Job entity)
        {
            var existingEntity = await _context.Jobs.FindAsync(id);
            if (existingEntity != null)
            {
                existingEntity.TaskList = entity.TaskList;
                existingEntity.Priority = entity.Priority;
                existingEntity.Id = id;
                await _context.SaveChangesAsync();
            }
            return existingEntity;
        }
    }
}
