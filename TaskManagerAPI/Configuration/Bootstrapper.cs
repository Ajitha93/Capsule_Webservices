using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerAPI.Helpers.Configuration;
using Unity.Mvc5;

namespace TaskManagerAPI.Configuration
{
    public class Bootstrapper
    {
        /// <summary>

        /// Initialise

        /// </summary>

        public static void Initialise()

        {

            IUnityContainer container = BuildUnityContainer();



            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }



        /// <summary>

        /// configure BusinessUnityConfiguration

        /// </summary>

        /// <returns></returns>

        private static IUnityContainer BuildUnityContainer()

        {

            return UnityConfiguration.Configure();

        }
    }
}