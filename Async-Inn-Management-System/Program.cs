using System;
using Async_Inn_Management_System.Data;
using Microsoft.EntityFrameworkCore;


           

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

string connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AsyncInnDbContext>(options => options.UseSqlServer(connString));


var app = builder.Build(); // it always should be after connString 


app.MapControllers();

app.MapGet("/", () => "Hello World!");


app.MapGet("/hey", () =>
{
    return "Hello, World!";
});


app.Run();

