using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApi.Models.Models;

namespace TaskManagerAPI.Business.TaskMaintenance
{
    public interface ITaskMaintenance
    {
        void InsertTask(TaskModel taskModel);
        List<TaskDetailsModel> GetTaskDetails(TaskSearchModel taskSearchModel);
        void DeleteTask(TaskModel taskModel);
        TaskModel GetTaskDetailsById(int taskId);
        List<TaskDetailsModel> GetParentTaskDetails();
    }
}
