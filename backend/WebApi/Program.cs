using Data.Factories;
using Data.Models;
using Data.Repositories;
using Data.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//ChatGPT - Behöver detta för att min frontend är på en annan port, då går inte anropen igenom
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

//ChatGPT - automatiskt konverterar strängar till enum, till exempel Avslutad = 2
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProjektRepository, ProjektRepository>();
builder.Services.AddScoped<IProjektService, ProjektService>();
builder.Services.AddScoped<ProjektFactory>();

var app = builder.Build();

// ChatGPT - öppnar upp för alla anrop
app.UseCors("AllowAllOrigins");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
