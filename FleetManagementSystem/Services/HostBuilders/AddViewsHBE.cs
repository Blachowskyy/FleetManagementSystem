
using FleetManagementSystem.ViewModels;
using FleetManagementSystem.ViewModels.ForkliftPagesVIewModels;
using FleetManagementSystem.ViewModels.InstallatorPagesViewModels;
using FleetManagementSystem.Views.InstallatorPages;
using FleetManagementSystem.Views.MainPages;
using FleetManagementSystem.Views.MainPages.ForkliftPages;
using FleetManagementSystem.Views.SuperUserPages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Services.HostBuilders
{
    public static class AddViewsHBE
    {
        public static IHostBuilder AddViews(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>(s =>
                new MainWindow(s.GetRequiredService<MainWindowViewModel>())
                );
                services.AddSingleton<LoginPage>(s =>
                new LoginPage(s.GetRequiredService<LoginPageViewModel>())
                );
                services.AddSingleton<AddUserPage>(s =>
                new AddUserPage(s.GetRequiredService<AddUsersPageViewModel>())
                );
                services.AddSingleton<AddForkliftPage>(s =>
                new AddForkliftPage(s.GetRequiredService<AddForkliftPageViewModel>())
                );
                services.AddSingleton<ForkliftsLiveMonitoringPage>(s =>
                new ForkliftsLiveMonitoringPage(s.GetRequiredService<ForkliftsLiveMonitoringPageViewModel>())
                );
                services.AddSingleton<LiveDataPage>(s =>
                new LiveDataPage(s.GetRequiredService<LiveDataPageViewModel>())
                );
                services.AddSingleton<TasksPage>(s =>
                new TasksPage(s.GetRequiredService<TasksPageViewModel>())
                );
                services.AddSingleton<CommandsPage>(s =>
                new CommandsPage(s.GetRequiredService<CommandsPageViewModel>())
                );
                services.AddSingleton<LidarLocPage>(s =>
                new LidarLocPage(s.GetRequiredService<LidarLocPageViewModel>())
                );
                services.AddSingleton<WorkstatesPage>(s =>
                new WorkstatesPage(s.GetRequiredService<WorkstatesPageViewModel>())
                );
                services.AddSingleton<AddLocationsPage>(s =>
                new AddLocationsPage(s.GetRequiredService<AddLocationsPageViewModel>())
                );
                services.AddSingleton<CustomJobsPage>(s =>
                new CustomJobsPage(s.GetRequiredService<CustomJobsPageViewModel>())
                );
            });
            return hostBuilder;
        }
    }
}
