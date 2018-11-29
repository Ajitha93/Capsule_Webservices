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
        [PerfCleanup]
        public void Cleanup(BenchmarkContext context)
        {
            taskManagerController = null; 
        }

    }
}
