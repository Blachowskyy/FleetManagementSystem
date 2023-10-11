using FleetManagementSystem.Models.Services.Interfaces;
using FleetManagementSystem.Services.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Models.Services
{
    public class JobStepDataService : IDataService<JobStep>
    {
        public readonly FMSDbContext _context;
        public JobStepDataService(FMSDbContext context)
        {
            _context = context;
        }
        public async Task<JobStep> Create(JobStep entity)
        {
            var addedEntity = _context.Tasks.Add(entity).Entity;
            await _context.SaveChangesAsync();
            return addedEntity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Tasks.FindAsync(id);
            if (entity !=  null)
            {
                _context.Tasks.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<JobStep> Get(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<IEnumerable<JobStep>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<JobStep> Update(int id, JobStep entity)
        {
            var existingEntity = await _context.Tasks.FindAsync(id);
            if (existingEntity != null)
            {
                existingEntity.TaskLocation = entity.TaskLocation;
                existingEntity.TaskType = entity.TaskType;
                existingEntity.Id = id;
                await _context.SaveChangesAsync();
            }
            return existingEntity;
        }
    }
}
