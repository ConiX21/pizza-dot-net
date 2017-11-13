using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DotNetPizza.Data;
using DotNetPizza.Models;
using DotNetPizza.Services;
using DotNetPizza.Models.Repository;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Mvc.Razor;

namespace DotNetPizza
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<DotNetPizzaDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DotNetPizzaConnection")));
            
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IRepository<Pizza>, RepositoryPizza>();
            services.AddTransient<IRepository<Client>, FakeRepositoryClient>();
            services.AddTransient<IRepository<Command>, FakeRepositoryCommand>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var assembly = typeof(MyComponentViewComponent.MyComponentViewComponent).GetTypeInfo().Assembly;
            var assemblyMessage = typeof(ConixComponents.MessageViewComponent).GetTypeInfo().Assembly;
            services.AddMvc();


            //var embeddedFileProvider = new EmbeddedFileProvider(
            //    assembly,
            //    "MyComponentViewComponent"
            //);

            var embeddedFileProviderMessage = new EmbeddedFileProvider(
                assemblyMessage,
                "ConixComponents"
            );

            //Add the file provider to the Razor view engine
            services.Configure<RazorViewEngineOptions>(options =>
            {
                //options.FileProviders.Add(embeddedFileProvider);
                options.FileProviders.Add(embeddedFileProviderMessage);
            });

            



            services.AddMemoryCache();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "areas",
                   template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //await SeedUserAdmin.EnsurePopulatedRoles(app);
            //await SeedUserAdmin.EnsurePopulatedUserAdmin(app);
        }
    }
}
