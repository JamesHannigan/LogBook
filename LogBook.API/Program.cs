using LogBook.BusinessLogic.Interface.Data;
using LogBook.BusinessLogic.Service.Data;
using LogBook.Data.Interface.Data;
using LogBook.Data.Models;
using LogBook.Data.Repository.Data;
using LogBook.DataLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings:DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll), ServiceLifetime.Transient);

//Services
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IActivityService, ActivityService>();

//Repositories
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<ILogTypeRepository, LogTypeRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectAssignmentRepository, ProjectAssignmentRepository>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
