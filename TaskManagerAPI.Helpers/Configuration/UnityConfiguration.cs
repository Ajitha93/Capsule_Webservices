using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerAPI.Business.TaskMaintenance;
using TaskManagerAPI.DataAccess.TaskRepository;

namespace TaskManagerAPI.Helpers.Configuration
{
    public class UnityConfiguration
    {
        public static IUnityContainer Configure()
        {

            IUnityContainer container = new UnityContainer();


            container.RegisterType<ITaskDataRepository, TaskDataRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<ITaskMaintenance, TaskMaintenance>(new HierarchicalLifetimeManager());

            return container;

        }

    }
}
