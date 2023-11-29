using Microsoft.EntityFrameworkCore;
using NotesApiCSharp.Data;
using NotesApiCSharp.Controllers;

// dotnet tool install -g Microsoft.dotnet-httprepl
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NotesSharpDb>(opt => opt.UseInMemoryDatabase("NotesSharp"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var users = app.MapGroup("/v1/users");

users.MapGet("/all", UserController.GetAll);
users.MapGet("/{id}", UserController.GetById);
users.MapPost("/register", UserController.Register);

app.Run();
