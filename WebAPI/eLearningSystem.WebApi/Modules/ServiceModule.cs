using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace eLearningSystem.WebApi.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //  var dataAccess = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(Assembly.Load("eLearningSystem.Services"))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(Assembly.Load("ManagementLibrary.Service"))
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope();
        }
    }
}