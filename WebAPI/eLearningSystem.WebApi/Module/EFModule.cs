using Autofac;
using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.UnitOfWork;
using eLearningSystem.WebApi.Module;
using System.Data.Entity;

namespace eLearningSystem.Services.IService
{   
    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterType(typeof(eLearningDataContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();
        }
    }
}