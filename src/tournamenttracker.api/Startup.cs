using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using TournamentWebApp.DataAccess;
using TournamentWebApp.Models;

namespace TournamentWebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add MVC services to the services container.
            services.AddMvc();

            services.AddSingleton(c => Configuration);

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<DataContext>(
                    options =>
                        options.UseSqlServer(
                            @"Server=(localdb)\MSSQLLocalDB;Database=TournamentTracker;Trusted_Connection=True;MultipleActiveResultSets=true"));

            services.AddScoped<DbContext, DataContext>();
            services.AddScoped<IGenericRepository<Tournament>, GenericRepository<Tournament, DbContext>>();

            // Uncomment the following line to add Web API services which makes it easier to port Web API 2 controllers.
            // You will also need to add the Microsoft.AspNet.Mvc.WebApiCompatShim package to the 'dependencies' section of project.json.
            // services.AddWebApiConventions();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Information;
            loggerFactory.AddConsole();

            // Configure the HTTP request pipeline.

            // Add the following to the request pipeline only in development environment.
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Add Error handling middleware which catches all application specific errors and
                // send the request to the following path or controller action.
                app.UseExceptionHandler("/Home/Error");
            }

            // Add static files to the request pipeline.
            app.UseStaticFiles();

            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                // Uncomment the following line to add a route for porting Web API 2 controllers.
                routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
            });

            SampleData.Initialize(app.ApplicationServices);
        }
    }
}
