using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Services.TaskServices
{
    public interface ITaskService<T>
    {
        Task<bool> TaskChange();
        Task<bool> TaskDelete();
        Task<bool> SendNewTask();
        Task<bool> TaskFinished();
        Task<T> TaskService();

    }
}
