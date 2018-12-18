using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerApi.Models.Models
{
   public class ProjectModel
    {
        public int Project_Id { get; set; }
        public string Project_Name { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public int Priority { get; set; }
        public bool Is_Active { get; set; }
        public int Employee_Id { get; set; }
        public int ProgressPercent { get; set; }
    }
}
