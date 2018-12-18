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
        int InsertTask(Task task);
        List<TaskDetailsModel> GetTaskDetails(TaskSearchModel taskSearchModel);
        void DeleteTask(Task task);
        TaskModel GetTaskDetailsById(int taskId);
        List<TaskDetailsModel> GetParentTaskDetails();
        void SaveUser(User user);
        void DeleteUser(User user);
        UserModel GetUserDetailsById(int UserId);
        List<UserModel> GetUserDetails();
        void DeleteProject(Project project);
        void SaveProject(Project project);
        List<ProjectModel> GetProjectDetails();
        ProjectModel GetProjectDetailsById(int ProjectId);
        void InsertarentTask(Parent_Task task);
    }
}
