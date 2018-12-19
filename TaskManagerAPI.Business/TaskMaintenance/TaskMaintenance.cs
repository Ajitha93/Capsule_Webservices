using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagerApi.Models.Models;
using TaskManagerAPI.DataAccess.TaskRepository;
using AutoMapper;
using TaskManagerAPI.DataAccess.Entity;

namespace TaskManagerAPI.Business.TaskMaintenance
{
    public class TaskMaintenance:ITaskMaintenance
    {
        public ITaskDataRepository _iTaskDataRepository;        
        public TaskMaintenance()
        {
            _iTaskDataRepository = new TaskDataRepository();
        }

        public void InsertTask(TaskModel taskModel)
        {
            if (taskModel.IsParent == true)
            {
                var task = Mapper.Map<TaskModel, Parent_Task>(taskModel);
                _iTaskDataRepository.InsertarentTask(task);
            }
            else
            {
                var task = Mapper.Map<TaskModel, Task>(taskModel);
                var taskId=_iTaskDataRepository.InsertTask(task);
                if (taskModel.EmployeeId != 0)
                {
                    var userModel = _iTaskDataRepository.GetUserDetailsById(taskModel.EmployeeId);
                    var user = Mapper.Map<UserModel, User>(userModel);
                    user.Task_Id = taskId;
                    _iTaskDataRepository.SaveUser(user);

                }
            }
        }
        public List<TaskDetailsModel> GetTaskDetails(TaskSearchModel taskSearchModel)
        {
            return _iTaskDataRepository.GetTaskDetails(taskSearchModel);
        }
        public void DeleteTask(TaskModel taskModel)
        {
            var task = Mapper.Map<TaskModel, Task>(taskModel);
            task.Status = "Completed";
            _iTaskDataRepository.DeleteTask(task);            
        }
        public TaskModel GetTaskDetailsById(int taskId)
        {
            return _iTaskDataRepository.GetTaskDetailsById(taskId);
        }
        public List<TaskDetailsModel> GetParentTaskDetails()
        {
            return _iTaskDataRepository.GetParentTaskDetails();
        }
        public void SaveUser(UserModel userModel)
        {
            var user = Mapper.Map<UserModel, User>(userModel);
            _iTaskDataRepository.SaveUser(user);
        }
        public void DeleteUser(UserModel userModel)
        {
            var user = Mapper.Map<UserModel, User>(userModel);
            _iTaskDataRepository.DeleteUser(user);
        }
        public List<UserModel> GetUsers()
        {
            return _iTaskDataRepository.GetUserDetails();
        }
        public UserModel GetUserDetailsById(int UserId)
        {
            return _iTaskDataRepository.GetUserDetailsById(UserId);
        }
        public void SaveProject(ProjectModel projectModel)
        {
            var proj = Mapper.Map<ProjectModel, Project>(projectModel);
            _iTaskDataRepository.SaveProject(proj);
            if(projectModel.Employee_Id!=0)
            {
                var userModel= _iTaskDataRepository.GetUserDetailsById(projectModel.Employee_Id);
                var user = Mapper.Map<UserModel, User>(userModel);
                user.Project_Id = projectModel.Project_Id;
                _iTaskDataRepository.SaveUser(user);

            }
        }
        public void DeleteProject(ProjectModel projectModel)
        {
            var proj = Mapper.Map<ProjectModel, Project>(projectModel);
            _iTaskDataRepository.DeleteProject(proj);
        }
        public List<ProjectModel> GetProjects()
        {
            var list= _iTaskDataRepository.GetProjectDetails();
            foreach(var l in list)
            {
                l.ProgressPercent = Convert.ToInt32(((l.Priority*100)/30));
                var details = _iTaskDataRepository.GetTaskDetailsByProjId(l.Project_Id);
                if (details != null && details.Count > 0)
                {
                    l.Status = details[0].Status;
                    l.NumberOfTasks = details.Count;
                }
            }
            return list;
        }
        public ProjectModel GetProjectDetailsById(int ProjectId)
        {
            return _iTaskDataRepository.GetProjectDetailsById(ProjectId);
        }
    }
}
