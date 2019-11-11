using Autofac;
using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.UnitOfWork;
using eLearningSystem.Services.IService;
using eLearningSystem.Services.Service;
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
            builder.RegisterType<UnitOfWork>().AsSelf();
            builder.RegisterType<UserService>().As<IUserService>();

            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new AutoMapperModule());
            builder.RegisterModule(new UnitOfWorkModule());
            builder.RegisterType<eLearningDataContext>().InstancePerLifetimeScope();
        }
    }
}