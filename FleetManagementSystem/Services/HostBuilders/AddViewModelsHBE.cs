using FleetManagementSystem.ViewModels;
using FleetManagementSystem.ViewModels.ForkliftPagesVIewModels;
using FleetManagementSystem.ViewModels.InstallatorPagesViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Services.HostBuilders
{
    public static class AddViewModelsHBE
    {
        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddTransient<MainWindowViewModel>();
                services.AddTransient<LoginPageViewModel>();
                services.AddTransient<AddUsersPageViewModel>();
                services.AddTransient<AddForkliftPageViewModel>();
                services.AddTransient<ForkliftsLiveMonitoringPageViewModel>();
                services.AddTransient<CommandsPageViewModel>();
                services.AddTransient<LidarLocPageViewModel>();
                services.AddTransient<LiveDataPageViewModel>();
                services.AddTransient<WorkstatesPageViewModel>();
                services.AddTransient<TasksPageViewModel>();
                services.AddTransient<AddLocationsPageViewModel>();
                services.AddTransient<CustomJobsPageViewModel>();
            });
            return hostBuilder;
        }
    }
}
