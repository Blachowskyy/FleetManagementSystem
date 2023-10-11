using FleetManagementSystem.Models;
using FleetManagementSystem.Models.Services;
using FleetManagementSystem.Models.Services.Interfaces;
using FleetManagementSystem.Services.Common;
using FleetManagementSystem.Services.Communication;
using FleetManagementSystem.Services.TaskServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Services.HostBuilders
{
    public static class AddServicesHBE
    {
        public static IHostBuilder AddServices(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<AppSettings>();
                services.AddSingleton<User>();
                services.AddScoped<Forklift>();
                services.AddSingleton<UserStore>();
                services.AddTransient<TaskType>();
                services.AddSingleton<JobStep>();
                services.AddSingleton<Location>();
                services.AddSingleton<Job>();
                services.AddTransient<TaskService>();
                services.AddSingleton<ConnectedForklifts>();
                services.AddSingleton<List<Forklift>>(provider => new List<Forklift>());
                services.AddSingleton<List<Location>>(provider => new List<Location>());
                services.AddSingleton<ForkliftConnectionService>();
                services.AddTransient<LocationDataService>();
                services.AddTransient<TaskTypeDataService>();
                services.AddTransient<JobStepDataService>();
                services.AddTransient<JobDataService>();
                services.AddTransient<ForkliftDataService>();
                services.AddTransient<IDataService<JobStep>, JobStepDataService>();
                services.AddTransient<IDataService<Job>, JobDataService>();
                services.AddTransient<IDataService<User>, UserDataService>();
                services.AddTransient<IDataService<Forklift>, ForkliftDataService>();
                services.AddTransient<IDataService<Job>, JobDataService>();
                services.AddTransient<IDataService<TaskType>, TaskTypeDataService>();
                services.AddTransient<IDataService<Location>, LocationDataService>();
                services.AddSingleton<IUserStore, UserStore>();
                services.AddTransient<ITcpConnection, ForkliftConnectionService>(provider => new ForkliftConnectionService());
            });
            return hostBuilder;
        }
    }
}
