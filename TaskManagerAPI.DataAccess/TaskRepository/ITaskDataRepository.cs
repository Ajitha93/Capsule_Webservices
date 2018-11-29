using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagerApi.Models.Models;
using TaskManagerAPI.DataAccess.Entity;

namespace TaskManagerAPI.DataAccess.TaskRepository
{
    public interface ITaskDataRepository
    {
        void InsertTask(Task task);
        List<TaskDetailsModel> GetTaskDetails(TaskSearchModel taskSearchModel);
        void DeleteTask(Task task);
        TaskModel GetTaskDetailsById(int taskId);
        List<TaskDetailsModel> GetParentTaskDetails();
    }
}
