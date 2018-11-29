using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerApi.Models.Models
{
    public class TaskSearchModel
    {
        public string ParentTask { get; set; }
        public string Task { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? PriorityFrom { get; set; }
        public int? PriorityTo { get; set; }
    }
}
