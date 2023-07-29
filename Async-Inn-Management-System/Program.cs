using System;
using System.Configuration;
using System.Text.Json.Serialization;
using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models.Interfaces;
using Async_Inn_Management_System.Models.Services;
using Microsoft.EntityFrameworkCore;


           

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Configure JSON serialization options
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});


string connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AsyncInnDbContext>(options => options.UseSqlServer(connString));





builder.Services.AddTransient<IHotel, HotelServices>();
builder.Services.AddTransient<IRoom, RoomService>();
builder.Services.AddTransient<IAmenity, AmenityService>();
builder.Services.AddTransient<IHotelRoom, HotelRoomRepository>();



var app = builder.Build(); // it always should be after connString 


app.MapControllers();

app.MapGet("/", () => "Hello World!");


app.MapGet("/hey", () =>
{
    return "Hello, World!";
});

//app.UseMvc();
app.Run();

