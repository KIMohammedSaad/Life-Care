using DonateMedicine.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonateMedicine.Models;

namespace DonateMedicine
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
            services.AddMvc(options => options.EnableEndpointRouting=false);
            //services.AddControllersWithViews();

            services.AddDbContext<HealthcareDbContext>(options => {
                options.UseInMemoryDatabase(Configuration.GetConnectionString("DefaultConnection"));
            });
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

            app.UseAuthorization();

          
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "login",
                    template: "{controller=Login}/{action=Login}");
                routes.MapRoute(
                   name: "register",
                   template: "{controller=Register}/{action=Index}");
                routes.MapRoute(
                    name: "adminhome",
                    template: "{controller=AdminHome}/{action=Index}");
                routes.MapRoute(
                    name: "addmedicine",
                    template: "{controller=AddMedicine}/{action=Index}");
                routes.MapRoute(
                    name: "adminViewDonations",
                    template: "{controller=AdminViewDonations}/{action=Index}");
                routes.MapRoute(
                    name: "adminViewRequests",
                    template: "{controller=AdminViewRequests}/{action=Index}");
                routes.MapRoute(
                    name: "userhome",
                    template: "{controller=UserHome}/{action=Index}");
                routes.MapRoute(
                    name: "userRequestMedicine",
                    template: "{controller=UserRequestMedicine}/{action=Index}");
                routes.MapRoute(
                    name: "userDonateMedicine",
                    template: "{controller=UserDonateMedicine}/{action=Index}");
                routes.MapRoute(
                    name: "userViewDonateMedicine",
                    template: "{controller=UserViewDonateMedicine}/{action=Index}");
            });
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<HealthcareDbContext>();
            SeedData(context);
        }
        public static void SeedData(HealthcareDbContext context)
        {
            Register user = new Register
            {
                Username = "Admin",
                Password = "Admin@123",
                Address = "Kochi- 83475983475",
                Age = 21,
                Gender = "Male"
            };
            context.Registers.Add(user);
            context.SaveChanges();
        }
    }
}
