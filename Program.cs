using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using TestTaskITPD.DAL;
using TestTaskITPD.DAL.Interfaces.Implementations;
using TestTaskITPD.DAL.Repositories;
using TestTaskITPD.Domain.Response;
using TestTaskITPD.Service.Implementations.Services;
using TestTaskITPD.Service.Interfaces.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add Cors
builder.Services.AddCors();

#region Register services
//Register services
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddScoped<ITaskCommentRepository, TaskCommentRepository>();
builder.Services.AddScoped<ITaskCommentService, TaskCommentService>();
#endregion

// Add DBContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


var app = builder.Build();

//Set Cors Policy
app.UseCors(c => c.AllowAnyHeader());
app.UseCors(c => c.AllowAnyOrigin());
app.UseCors(c => c.AllowAnyMethod());
app.UseCors(c => c.WithOrigins("https://localhost:44421"));

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseExceptionHandler(c => c.Run(async context =>
{
    var exception = context.Features
        .Get<IExceptionHandlerPathFeature>()
        ?.Error;
    var response = new BaseResponse<string>(){ Description = exception.Message ,StatusCode = HttpStatusCode.InternalServerError };
    await context.Response.WriteAsJsonAsync(response);
}));

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
