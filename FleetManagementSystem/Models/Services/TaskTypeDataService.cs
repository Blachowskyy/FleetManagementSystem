using FleetManagementSystem.Models.Services.Interfaces;
using FleetManagementSystem.Services.DataBase;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Models.Services
{
    public class TaskTypeDataService : IDataService<TaskType>
    {
        private readonly FMSDbContext _context;
        public TaskTypeDataService(FMSDbContext context)
        {
            _context = context;
        }
        public Task<TaskType> Create(TaskType entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TaskType> Get(int id)
        {
            return await _context.TaskTypes.FindAsync(id);
        }

        public async Task<IEnumerable<TaskType>> GetAll()
        {
            return await _context.TaskTypes.ToListAsync();
        }

        public Task<TaskType> Update(int id, TaskType entity)
        {
            throw new NotImplementedException();
        }
    }
}
