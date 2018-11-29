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
            var task=Mapper.Map<TaskModel,Task>(taskModel);
            _iTaskDataRepository.InsertTask(task);
        }
        public List<TaskDetailsModel> GetTaskDetails(TaskSearchModel taskSearchModel)
        {
            return _iTaskDataRepository.GetTaskDetails(taskSearchModel);
        }
        public void DeleteTask(TaskModel taskModel)
        {
            var task = Mapper.Map<TaskModel, Task>(taskModel);
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
    }
}
