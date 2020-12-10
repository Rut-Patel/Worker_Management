using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Threading.Tasks;
using Worker_Management.Models;
using Microsoft.AspNetCore.Mvc;
//Installing by Nu-get Package Manager.
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
//we also need to install (but not import) Microsoft.EntityFrameworkCore.Tools
using Worker_Management.Data;
using Microsoft.AspNetCore.Identity;

namespace Worker_Management
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
            services.AddControllersWithViews();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //Here, we disable endpoint routing. This was an issue when upgrading from ASP.NET CORE 2.0 to ASP.NET Core 3.0
            services.AddMvc(options => options.EnableEndpointRouting = false);
            //Adding connection
            string con_worker = @"Server=(localdb)\mssqllocaldb;Database=Worker_Management;Trusted_Connection=True;ConnectRetryCount=0";
            //Adding Db Context
            services.AddDbContext<WorkerContext>(options => options.UseSqlServer(con_worker));
            //Default.
            services.AddControllersWithViews();
            //Added by me.
            services.AddRazorPages();
            services.AddMvc();
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {    
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvcWithDefaultRoute();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"); 
            });
        }
    }
}
