using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace eLearningSystem.WebApi.Module
{
    public class ServiceModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(Assembly.Load("eLearningSystem.Services"))

                      .Where(t => t.Name.EndsWith("Service"))

                      .AsImplementedInterfaces()

                      .InstancePerLifetimeScope();

        }

    }
}