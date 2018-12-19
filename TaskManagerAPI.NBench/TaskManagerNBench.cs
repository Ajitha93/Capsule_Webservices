using NBench;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApi.Models.Models;
using TaskManagerAPI.Controllers;
using TaskManagerAPI.Helpers.Mappings;

namespace TaskManagerAPI.NBench
{
    public class TaskManagerNBench : PerformanceTestStuite<TaskManagerNBench>
    {
       
        TaskMangerController taskManagerController = null;        

        private const int AcceptableMinAddThroughput = 500;
       

        [PerfSetup]
        public void SetUp(BenchmarkContext context)
        {
            AutoMapperConfiguration.Configure();
            taskManagerController = new TaskMangerController();           
        }
        
        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 600000)]
        public void GetParentTaskDetails()
        {
            var response = taskManagerController.GetParentTaskDetails();          
        }
        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 600000)]
        public void GetTaskById()
        {
            var task = new TaskModel()
            {
                TaskId = 4
            };
            var results = taskManagerController.GetTaskById(task);
        }
        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 600000)]
        public void DeleteTask()
        {
            var task = new TaskModel()
            {
                TaskId = 10
            };
            taskManagerController.DeleteTask(task);
        }
        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 600000)]
        public void ViewTasks()
        {
            var taskSearchModel = new TaskSearchModel()
            {
                Task = "Nunit Test"
            };
            var results = taskManagerController.ViewTasks(taskSearchModel);
        }
        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 600000)]
        public void AddTask()
        {
            var task = new TaskModel() {
                Task = "NBench Test",
                ParentTaskId = 1,
                Priority = 10,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(8)
            };
            taskManagerController.AddTask(task);           
        }
        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 600000)]
        public void AddUser()
        {           
                UserModel user = new UserModel();
                user.Employee_Id = 1002;
                user.First_Name = "NBench First";
                user.Last_Name = "NBench Last";
                taskManagerController.AddUser(user);           
        }
        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 600000)]
        public void ViewUsers()
        {
                var results = taskManagerController.ViewUsers();           
        }
        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 600000)]
        public void DeleteUser()
        {
                var user = new UserModel()
                {
                    User_Id = 1
                };
            taskManagerController.DeleteUser(user);
           
        }
        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 600000)]
        public void GetUserById()
        {
           
                var user = new UserModel()
                {
                    User_Id = 1
                };
                var results = taskManagerController.GetUserById(user);
            
        }
        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 600000)]
        public void AddProject()
        {
           
                ProjectModel project = new ProjectModel();
                project.Project_Name = "NBench Project";
                project.Priority = 10;
            taskManagerController.AddProject(project);
         
        }
        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 600000)]
        public void ViewProjects()
        {
           
                var results = taskManagerController.ViewProjects();
            
        }
        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 600000)]
        public void DeleteProject()
        {
            
                var proj = new ProjectModel()
                {
                    Project_Id = 1
                };
            taskManagerController.DeleteProject(proj);
           
        }
        [PerfCleanup]
        public void Cleanup(BenchmarkContext context)
        {
            taskManagerController = null; 
        }

    }
}
