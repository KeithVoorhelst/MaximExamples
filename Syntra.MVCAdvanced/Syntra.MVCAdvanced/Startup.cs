using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Syntra.MVCAdvanced.DB;
using Syntra.MVCAdvanced.Services;
using Syntra.MVCAdvanced.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syntra.MVCAdvanced
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

            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();
            //services.AddSingleton<ITeacherDbService, TeacherDbService>(); // 1 X new TeacherDbService geeft dat aan alle 10!
            //services.AddTransient<ITeacherDbService, TeacherDbService>(); // 10 X new TeacherDbService geeft dan aan alle 10 een nieuwe!
            services.AddScoped<ITeacherDbService, TeacherDbService>(); // 10 X new TeacherDbService geeft dan aan alle 10 een nieuwe!
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ICourseService, CourseService>();

            services.AddDbContext<DanceSchoolDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("letsDanceConnectionString")));
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
