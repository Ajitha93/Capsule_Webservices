using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerApi.Models.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public int ParentTaskId { get; set; }
        public string Task { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsParent { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public string Status { get; set; }
    }
}
