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
    }
}
