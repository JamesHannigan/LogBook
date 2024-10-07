namespace LogBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();

////builder.Configuration.GetValue<string>("DefaultConnection");

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll), ServiceLifetime.Transient);

////Services
//builder.Services.AddScoped<IActivityService, ActivityService>();
//builder.Services.AddScoped<IProjectService, ProjectService>();
//builder.Services.AddScoped<IAccountService, AccountService>();

////Repositories
//builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
//builder.Services.AddScoped<ILogTypeRepository, LogTypeRepository>();
//builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
//builder.Services.AddScoped<IProjectAssignmentRepository, ProjectAssignmentRepository>();

//builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

//builder.Services.Configure<SecurityStampValidatorOptions>(o => o.ValidationInterval = TimeSpan.FromDays(31)); //Determines the amount of time a user is logged in for

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/Authentication";
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}


//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();