using System;
using System.Collections.Generic;

namespace DataStorage.Models
{
    public partial class Task
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
