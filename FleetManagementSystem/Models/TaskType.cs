using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Models
{
    public class TaskType : BaseModel
    {

        public int Type { get; set; }
        public string Description { get; set; }
    }
}
