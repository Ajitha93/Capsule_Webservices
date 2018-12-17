using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagerApi.Models.Models;
using TaskManagerAPI.DataAccess.Entity;

namespace TaskManagerAPI.DataAccess.TaskRepository
{
    public class TaskDataRepository : ITaskDataRepository
    {
        TaskManagerEntities taskManagerEntities;
        public void InsertTask(Task task)
        {
            using ( taskManagerEntities = new TaskManagerEntities())
            {
                task.Is_Active = true;
                if (task.Task_Id == 0)
                {                    
                    taskManagerEntities.Tasks.Add(task);
                    taskManagerEntities.Entry(task).State = System.Data.Entity.EntityState.Added;
                }
                else
                {                   
                    taskManagerEntities.Tasks.Add(task);
                    taskManagerEntities.Entry(task).State = System.Data.Entity.EntityState.Modified;
                }
                taskManagerEntities.SaveChanges();
            }
        }
        public List<TaskDetailsModel> GetTaskDetails(TaskSearchModel taskSearchModel)
        {
            using ( taskManagerEntities = new TaskManagerEntities())
            {
                var result = (from t in taskManagerEntities.Tasks
                              join p in taskManagerEntities.Parent_Task
                              on t.Parent_Task_Id equals p.Parent_Task_Id
                              where ((taskSearchModel.Task == null || taskSearchModel.Task==""||
                              t.Task1.ToLower().Contains(taskSearchModel.Task.ToLower()))
                              && (taskSearchModel.ParentTask == null || taskSearchModel.ParentTask ==""||
                              p.Parent_Task1.ToLower().Contains(taskSearchModel.ParentTask.ToLower()))
                              && (taskSearchModel.PriorityFrom==null||t.Priority>=taskSearchModel.PriorityFrom)
                              && (taskSearchModel.PriorityTo == null || t.Priority <= taskSearchModel.PriorityTo)
                              && (taskSearchModel.StartDate == null || t.Start_Date == taskSearchModel.StartDate)
                              && (taskSearchModel.EndDate == null || t.End_Date == taskSearchModel.EndDate)
                              )
                              select new TaskDetailsModel()
                              {
                                  TaskId = t.Task_Id,
                                  ParentTaskId = t.Parent_Task_Id,
                                  Task = t.Task1,
                                  ParentTask = p.Parent_Task1,
                                  Priority = t.Priority,
                                  StartDate = t.Start_Date,
                                  EndDate = t.End_Date,
                                  IsActive=t.Is_Active
                              }).ToList();
                return result;
            }
        }
        public void DeleteTask(Task task)
        {
            using ( taskManagerEntities = new TaskManagerEntities())
            {
                task.Is_Active = false;                
                taskManagerEntities.Tasks.Add(task);
                taskManagerEntities.Entry(task).State = System.Data.Entity.EntityState.Modified;
                //taskManagerEntities.Entry(task).State = System.Data.Entity.EntityState.Deleted;
                taskManagerEntities.SaveChanges();
            }
        }
        public TaskModel GetTaskDetailsById(int taskId)
        {
            using (taskManagerEntities = new TaskManagerEntities())
            {
                var result = (from t in taskManagerEntities.Tasks
                              where t.Task_Id == taskId
                              select new TaskModel()
                              {
                                  TaskId = t.Task_Id,
                                  ParentTaskId = t.Parent_Task_Id,
                                  Task = t.Task1,                                  
                                  Priority = t.Priority,
                                  StartDate = t.Start_Date,
                                  EndDate = t.End_Date,                                  
                                  IsActive=t.Is_Active
                              }).FirstOrDefault();
                return result;          
            }
        }
        public List<TaskDetailsModel> GetParentTaskDetails()
        {
            using (taskManagerEntities = new TaskManagerEntities())
            {
                var result = taskManagerEntities.Parent_Task.
                    Select(x=> new TaskDetailsModel { ParentTaskId = x.Parent_Task_Id,
                        ParentTask=x.Parent_Task1 }).ToList();
                return result;
            }
        }
        public void SaveUser(User user)
        {
            using (taskManagerEntities = new TaskManagerEntities())
            {
                user.Is_Active = true;
                if (user.User_Id == 0)
                {
                    taskManagerEntities.Users.Add(user);
                    taskManagerEntities.Entry(user).State = System.Data.Entity.EntityState.Added;
                }
                else
                {
                    taskManagerEntities.Users.Add(user);
                    taskManagerEntities.Entry(user).State = System.Data.Entity.EntityState.Modified;
                }
                taskManagerEntities.SaveChanges();
            }
        }
        public void DeleteUser(User user)
        {
            using (taskManagerEntities = new TaskManagerEntities())
            {
                user.Is_Active = false;
                taskManagerEntities.Users.Add(user);
                taskManagerEntities.Entry(user).State = System.Data.Entity.EntityState.Modified;
                taskManagerEntities.SaveChanges();
            }
        }
        public List<UserModel> GetUserDetails()
        {
            using (taskManagerEntities = new TaskManagerEntities())
            {
                var details = (from u in taskManagerEntities.Users
                               where u.Is_Active==true
                               select new UserModel
                               {
                                   User_Id = u.User_Id,
                                   First_Name = u.First_Name,
                                   Last_Name = u.Last_Name,
                                   Employee_Id = u.Employee_Id,
                                   Is_Active = u.Is_Active
                               }).ToList();
                return details;
            }
        }
        public UserModel GetUserDetailsById(int UserId)
        {
            using (taskManagerEntities = new TaskManagerEntities())
            {
                var details = (from u in taskManagerEntities.Users
                               where u.User_Id== UserId
                               select new UserModel
                               {
                                   User_Id = u.User_Id,
                                   First_Name = u.First_Name,
                                   Last_Name = u.Last_Name,
                                   Employee_Id = u.Employee_Id,
                                   Is_Active = u.Is_Active
                               }).FirstOrDefault();
                return details;
            }
        }
    }           
}
