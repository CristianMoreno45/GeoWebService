using Microsoft.EntityFrameworkCore;
using UnalColombia.Geomatic.Geodb.Domain.AggregateModels;
using UnalColombia.Geomatic.Geodb.Infrastructure.Context;
using UnalColombia.Geomatic.Geodb.Infrastructure.Repositories;
using UnalColombia.Geomatic.Geodb.Services.Handlers;

var builder = WebApplication.CreateBuilder(args);


// Add Database provider connection
builder.Services.AddDbContextPool<GeoDataBaseContext>(opt => {
    opt.UseNpgsql(
        builder.Configuration.GetConnectionString("GeoDataBaseContext"),
        o => o.UseNetTopologySuite());
    });

builder.Services.AddScoped<IGeoEvent, GeoEvent>();
builder.Services.AddScoped<IGeoEventRepository, GeoEventRepository>();
builder.Services.AddScoped<IGeoEventHandler, GeoEventHandler>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
