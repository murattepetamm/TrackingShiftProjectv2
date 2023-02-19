using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.AppDbContext;
using DataAccess.Concrete;
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
using static DataAccess.Abstract.IRepository;

namespace UI
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
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddSession();
            services.AddMemoryCache();
            //services.AddDbContext<AppDb_Context>(options =>
            //   options.UseSqlServer(Configuration.GetConnectionString("ConnectionStrings")));

            //services.AddTransient<IEmployeeDal, EmployeeRepository>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddScoped<ITeamDal, TeamRepository>();
            services.AddScoped<ITitleDal, TitleRepository>();
            services.AddScoped<IShiftDal, ShiftRepository>();
            services.AddScoped<IEmployeeDal, EmployeeRepository>();
            services.AddScoped<IShiftOfTeamDal, ShiftOfTeamRepository>();
            services.AddScoped<ITeamOfEmployeeDal, TeamOfEmployeeRepository>();

            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<ITitleService, TitleManager>();
            services.AddScoped<ITeamService, TeamManager>();
            services.AddScoped<IShiftService, ShiftManager>();
            services.AddScoped<IShiftOfTeamService, ShiftOfTeamManager>();
            services.AddScoped<ITeamOfEmployeeService, TeamOfEmployeeManager>();


            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddDbContext<AppDb_Context>();

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
                    pattern: "{controller=Employee}/{action=Index}/{id?}");
            });
        }
    }
}
