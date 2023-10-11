using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Services.DataBase
{
    public class DTFMSContextFactory
    {
        public FMSDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<FMSDbContext>();
            optionsBuilder.UseSqlite("Data Source=FMSData.db");
            return new FMSDbContext(optionsBuilder.Options);
        }
    }
}
