using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Models.Services.Interfaces
{
    public interface ITcpConnection
    {
        Task<bool> ConnectToServer(Forklift forklift);
        Task HandleForkliftConnectionAsync(Forklift forklift);
        Task<bool> Disconnect(Forklift forklift);

    }
}
