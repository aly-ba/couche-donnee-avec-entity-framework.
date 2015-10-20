
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Diagnostics.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Routing;
using Microsoft.Data.Entity;
//using Microsoft.Framework.Cache.Memory;

using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using ASPNET5Samurai.DataModel;

namespace ASPNET5Samurai
{
    public class Startup
    {
        public static IConfiguration configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            configuration = new Configuration().AddJsonFile("config.json").AddEnvironmentVariables();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Add EF services to the services container.
            services.AddEntityFramework(configuration)
                .AddSqlServer()
                .AddDbContext<SamuraiContext>(options => options.UseSqlServer());
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
            app.UseWelcomePage();
        }
    }
}
