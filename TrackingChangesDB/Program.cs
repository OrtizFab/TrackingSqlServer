using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TrackingChangesDB;
using HostedServices = Microsoft.Extensions.Hosting;
using TrackingChangesDB.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<TrackingDbContext>(
//    options => options.UseSqlServer(builder.Configuration.GetConnectionString("myConnection")));
builder.Services.AddSingleton<HostedServices.IHostedService, SqlDependencyService>();

builder.Services.AddScoped<SqlDependencyService>();
    builder.Services.AddSignalR();

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
