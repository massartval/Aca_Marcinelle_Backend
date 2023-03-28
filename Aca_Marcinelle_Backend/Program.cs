using Aca_Marcinelle_Backend.DAL.Entities;
using Aca_Marcinelle_Backend.DAL.Interfaces;
using Aca_Marcinelle_Backend.DAL.Services;
using Aca_Marcinelle_Backend.DAL.Tools;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Swagger/OpenAPI https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Enable Cors
builder.Services.AddCors(c => c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

//Connection
builder.Services.AddTransient(c => new Connection(builder.Configuration.GetConnectionString("Default")));

//Repositories
builder.Services.AddScoped<IGenericRepository<Person>, PersonRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");

// app.UseRouting(); ???

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

Debug.WriteLine("HELLO");