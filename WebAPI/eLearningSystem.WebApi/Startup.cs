using eLearningSystem.Data.Migrations;
using eLearningSystem.Data.Model;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;

[assembly: OwinStartup(typeof(eLearningSystem.WebApi.Startup))]

namespace eLearningSystem.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<eLearningDataContext, Configuration>());
        }
    }
}