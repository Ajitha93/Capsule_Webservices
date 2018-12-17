using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerApi.Models.Models
{
    public class UserModel
    {
        public int User_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Employee_Id { get; set; }
        public int Project_Id { get; set; }
        public int Task_Id { get; set; }
        public bool Is_Active { get; set; }
    }
}
