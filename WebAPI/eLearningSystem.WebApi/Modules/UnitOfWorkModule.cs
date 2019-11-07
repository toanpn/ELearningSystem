﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace eLearningSystem.WebApi.Modules
{
    public class UnitOfWorkModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("eLearningSystem.Repositories"))
                .Where(t => t.Name.EndsWith("UnitOfWork"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}