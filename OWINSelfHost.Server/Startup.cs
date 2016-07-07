using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(OWINSelfHost.Server.Startup))]

namespace OWINSelfHost.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = CreateWebApiConfiguration();
            app.UseWebApi(config);
        }

        private HttpConfiguration CreateWebApiConfiguration()
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            return config;
        }
    }
}
