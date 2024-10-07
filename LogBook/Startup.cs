using LogBook.BusinessLogic.Interface.Data;
using LogBook.BusinessLogic.Interface.System;
using LogBook.BusinessLogic.Service.Data;
using LogBook.BusinessLogic.Service.System;
using LogBook.Data.Interface.Data;
using LogBook.Data.Models;
using LogBook.Data.Repository.Data;
using LogBook.DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LogBook
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllersWithViews();

            //builder.Configuration.GetValue<string>("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll), ServiceLifetime.Transient);

            //Services
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IAccountService, AccountService>();

            //Repositories
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<ILogTypeRepository, LogTypeRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectAssignmentRepository, ProjectAssignmentRepository>();

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.Configure<SecurityStampValidatorOptions>(o => o.ValidationInterval = TimeSpan.FromDays(31)); //Determines the amount of time a user is logged in for

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Authentication";
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (!env.IsDevelopment())
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
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }

                //app.MapControllerRoute(
                //name: "default",
                //pattern: "{controller=Home}/{action=Index}/{id?}");

            //app.Run();
    }
}