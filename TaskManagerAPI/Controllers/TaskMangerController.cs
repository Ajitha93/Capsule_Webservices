using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagerAPI.Business.TaskMaintenance;
using TaskManagerApi.Models.Models;
using Microsoft.Practices.Unity;
using System.Web.Http.Cors;

namespace TaskManagerAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TaskMangerController : ApiController
    {
        public ITaskMaintenance _ITaskMaintenance;        
        public TaskMangerController()
        {
            _ITaskMaintenance = new TaskMaintenance();
        }
        [HttpPost]
        public void AddTask([FromBody]TaskModel taskModel)
        {  
            _ITaskMaintenance.InsertTask(taskModel);
        }
        [HttpPost]
        public List<TaskDetailsModel> ViewTasks(TaskSearchModel taskSearchModel)
        {
           return  _ITaskMaintenance.GetTaskDetails(taskSearchModel);
        }

        [HttpPost]        
        public void DeleteTask([FromBody]TaskModel taskModel)
        {
            var task = _ITaskMaintenance.GetTaskDetailsById(taskModel.TaskId);
            if(task!=null)
            _ITaskMaintenance.DeleteTask(task);
        }
        [HttpPost]
        public TaskModel GetTaskById(TaskModel taskModel)
        {
            var task = _ITaskMaintenance.GetTaskDetailsById(taskModel.TaskId);
            return task;
        }
        [HttpGet]
        public List<TaskDetailsModel> GetParentTaskDetails()
        {
            return _ITaskMaintenance.GetParentTaskDetails();
        }
        [HttpPost]
        public void AddUser([FromBody]UserModel userModel)
        {
            _ITaskMaintenance.SaveUser(userModel);
        }
        [HttpPost]
        public List<UserModel> ViewUsers()
        {
            return _ITaskMaintenance.GetUsers();
        }

        [HttpPost]
        public void DeleteUser([FromBody]UserModel userModel)
        {
            var user = _ITaskMaintenance.GetUserDetailsById(userModel.User_Id);
            if (user != null)
                _ITaskMaintenance.DeleteUser(user);
        }
        [HttpPost]
        public UserModel GetUserById(UserModel userModel)
        {
            var user = _ITaskMaintenance.GetUserDetailsById(userModel.User_Id);
            return user;
        }
        [HttpPost]
        public void AddProject([FromBody]ProjectModel projectModel)
        {
            _ITaskMaintenance.SaveProject(projectModel);
        }
        [HttpPost]
        public List<ProjectModel> ViewProjects()
        {
            return _ITaskMaintenance.GetProjects();
        }

        [HttpPost]
        public void DeleteProject([FromBody]ProjectModel projectModel)
        {
            var proj = _ITaskMaintenance.GetProjectDetailsById(projectModel.Project_Id);
            if (proj != null)
                _ITaskMaintenance.DeleteProject(proj);
        }
    }
}
