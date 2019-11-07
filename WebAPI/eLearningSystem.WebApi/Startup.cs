using eLearningSystem.Data.Model;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using System.Web.Http;

[assembly: OwinStartup(typeof(eLearningSystem.WebApi.Startup))]

namespace eLearningSystem.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            ConfigureAuth(app);
            config.EnableCors();

            WebApiConfig.Register(config);
            app.UseWebApi(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }
    }
}