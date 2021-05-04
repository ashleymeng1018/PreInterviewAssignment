using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Models
{
    public class TaskDTO
    {
        public string Name { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
