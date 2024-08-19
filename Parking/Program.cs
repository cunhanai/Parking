using Parking.Infra.Data.Extensions;
using Parking.Application.Extensions;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure application
builder.Services.AddInfrastructure()
                .MigrateDatabase()
                .AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


var supportedCultures = new[] {
    new CultureInfo("pt-BR")
};

app.UseRouting()
.UseCors(cors => cors
      .AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader()
).UseRequestLocalization(new RequestLocalizationOptions()
{
    DefaultRequestCulture = new RequestCulture("pt-BR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.UseAuthorization();

app.MapControllers();

app.Run();
