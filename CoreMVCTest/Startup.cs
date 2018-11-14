using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMVCTest.Models;
using CoreMVCTest.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreMVCTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            // Custom entry
            services.Add(new ServiceDescriptor(typeof(ILog), new MyConsoleLogger()));
           
            services.Add(new ServiceDescriptor(typeof(List<TestModel>), new List<TestModel> { new TestModel { Id = 1, FirstName = "Jason", LastName = "Prouse" } }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            /*
            app.UseHttpsRedirection();
            
            app.UseCookiePolicy();
            */
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Test}/{action=Index}/{id?}");
            });




            /* app.Run(async (context) =>
             {
                 await context.Response.WriteAsync("Hello World!");

             });*/

            /* RequestDelegate requestDelegate = async (context) => await context.Response.WriteAsync("Hello World!");
             app.Run(requestDelegate);*/

            /*app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello World From 1st Middleware!");

                await next();
            });*/

            //OR

            app.UseWelcomePage();

            //app.Use(testMethod2);

            //app.Run(testMethod);

            //app.Run(context => { throw new Exception("Error"); });

        }

        private async Task testMethod(HttpContext context)
        {
            await context.Response.WriteAsync("Hello World! ");
        }

        private Task testMethod2(HttpContext context, Func<Task> nex)
        {
            context.Response.WriteAsync("Hello World From 1st Middleware!");

            //This returns the contents of the Func, in this case, Task
            return nex();
        }
    }
}
