using FleetManagementSystem.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Models
{
    public class ConnectedForklifts : BaseModel
    {
        public Forklift Forklift { get; set; }
        public ForkliftConnectionService ConnectionService { get; set; }

    }
}
