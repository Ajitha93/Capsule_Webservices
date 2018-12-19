using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagerAPI;
using TaskManagerAPI.Controllers;
using TaskManagerApi.Models.Models;
using Moq;
using TaskManagerAPI.Business.TaskMaintenance;
using NUnit.Framework;
using AutoMapper;
using TaskManagerAPI.DataAccess.Entity;
using TaskManagerAPI.Helpers.Mappings;

namespace TaskManagerAPI.Tests.Controllers
{
    [TestFixture]
    public class TaskManagerControllerTest
    {       
        TaskMangerController taskMangerController;
        public TaskManagerControllerTest()
        {
            AutoMapperConfiguration.Configure();
            taskMangerController = new TaskMangerController();
        }

         [Test]
        public void AddTask()
        {
            try
            {                
                TaskModel task = new TaskModel();
                task.Task= "Nunit Test";
                task.ParentTaskId = 1;
                task.Priority = 10;
                task.StartDate = DateTime.Now;
                task.EndDate = DateTime.Now.AddDays(7);
                task.ProjectId = 1;
                taskMangerController.AddTask(task);               
                
            }
            catch (Exception)
            {
                Assert.Fail("API Failed");                
            }
        }
        [Test]
        public void ViewTasks()
        {
            try
            {
                var taskSearchModel = new TaskSearchModel()
                {
                    Task = "Nunit Test"
                };
                var results = taskMangerController.ViewTasks(taskSearchModel);               
            }
            catch(Exception)
            {
                Assert.Fail("API Failed");
            }
        }
        [Test]
        public void DeleteTask()
        {
            try
            {
                var task = new TaskModel()
                {
                    TaskId = 1
                };
                taskMangerController.DeleteTask(task);               

            }
            catch (Exception)
            {
                Assert.Fail("API Failed");
            }
        }
        [Test]
        public void GetTaskById()
        {
            try
            {
                var task = new TaskModel()
                {
                    TaskId = 1
                };
                var results = taskMangerController.GetTaskById(task);
            }
            catch (Exception)
            {
                Assert.Fail("API Failed");
            }
        }
        [Test]
        public void GetParentTaskDetails()
        {
            try
            {
                var results = taskMangerController.GetParentTaskDetails();
            }
            catch (Exception)
            {
                Assert.Fail("API Failed");
            }
        }
        [Test]
        public void AddUser()
        {
            try
            {
                UserModel user = new UserModel();
                user.Employee_Id = 1002;
                user.First_Name = "NUnit First";
                user.Last_Name = "Nunit Last";                
                taskMangerController.AddUser(user);
            }
            catch (Exception)
            {
                Assert.Fail("API Failed");
            }
        }
        [Test]
        public void ViewUsers()
        {
            try
            {
                var results = taskMangerController.ViewUsers();
            }
            catch (Exception)
            {
                Assert.Fail("API Failed");
            }
        }
        [Test]
        public void DeleteUser()
        {
            try
            {
                var user = new UserModel()
                {
                    User_Id = 1
                };
                taskMangerController.DeleteUser(user);

            }
            catch (Exception)
            {
                Assert.Fail("API Failed");
            }
        }
        [Test]
        public void GetUserById()
        {
            try
            {
                var user = new UserModel()
                {
                    User_Id = 1
                };
                var results = taskMangerController.GetUserById(user);
            }
            catch (Exception)
            {
                Assert.Fail("API Failed");
            }
        }
        [Test]
        public void AddProject()
        {
            try
            {
                ProjectModel project = new ProjectModel();
                project.Project_Name = "Nunit Project";
                project.Priority = 10;
                taskMangerController.AddProject(project);
            }
            catch (Exception)
            {
                Assert.Fail("API Failed");
            }
        }
        [Test]
        public void ViewProjects()
        {
            try
            {
                var results = taskMangerController.ViewProjects();
            }
            catch (Exception)
            {
                Assert.Fail("API Failed");
            }
        }
        [Test]
        public void DeleteProject()
        {
            try
            {
                var proj = new ProjectModel()
                {
                    Project_Id = 1
                };
                taskMangerController.DeleteProject(proj);

            }
            catch (Exception)
            {
                Assert.Fail("API Failed");
            }
        }
    }
}
            
       