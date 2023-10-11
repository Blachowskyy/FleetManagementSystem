using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Services.DataBase
{
    public class FMSDbContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> _configure;
        public FMSDbContextFactory(Action<DbContextOptionsBuilder> confgure)
        {
            _configure = confgure;
        }
        public FMSDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<FMSDbContext> options = new DbContextOptionsBuilder<FMSDbContext>();
            options.UseSqlite("Data Source = FMS_Data.db");
            _configure(options);
            return new FMSDbContext(options.Options);
        }
    }
}
