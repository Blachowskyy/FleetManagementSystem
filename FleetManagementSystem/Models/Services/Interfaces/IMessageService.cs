﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Models.Services.Interfaces
{
    public interface IMessageService
    {
        void ShowMessage(string message);
        void CloseMessage();
    }
}
