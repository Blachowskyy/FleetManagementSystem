using FleetManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Services.Common
{
    public interface IUserStore
    {
        User CurrentUser { get; set; }
        event Action StateChanged;
    }
}
