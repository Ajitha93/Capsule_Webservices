using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerApi.Models.Models
{
    public class TaskDetailsModel
    {
        public int TaskId { get; set; }
        public int ParentTaskId { get; set; }
        public string ParentTask { get; set; }
        public string Task { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }

    }
}
