using FleetManagementSystem.Models;
using FleetManagementSystem.Services.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Services.Common
{
    public class NonQueryDataService<T> where T : BaseModel
    {
        private readonly FMSDbContextFactory _contextFactory;
        public NonQueryDataService(FMSDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<T> Create(T entity)
        {
            using FMSDbContext context = _contextFactory.CreateDbContext();
            EntityEntry<T> createResult = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return createResult.Entity;
        }
        public async Task<T> Update(int id, T entity)
        {
            using FMSDbContext context = _contextFactory.CreateDbContext();
            entity.Id = id;
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> Delete(int id)
        {
            using FMSDbContext context = _contextFactory.CreateDbContext();
            T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
