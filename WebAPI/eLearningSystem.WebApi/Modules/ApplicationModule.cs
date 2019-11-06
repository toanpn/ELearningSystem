using Autofac;
using eLearningSystem.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eLearningSystem.WebApi.Modules
{
    public class ApplicaitonModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new AutoMapperModule());
            builder.RegisterModule(new UnitOfWorkModule());
            builder.RegisterType<eLearningDataContext>().InstancePerLifetimeScope();
        }
    }
}