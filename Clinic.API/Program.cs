using Clinic.Infrastructure.Extensions;
using  Clinic.Application.Extensions;
using Clinic.Shared.Infrastructure.DIExtensions;
using Carter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddClinicInfrastructure(builder.Configuration);
builder.Services.AddClinicApplicationServices();
builder.Services.AddSharedInfrastructure(builder.Configuration);

builder.Services.AddCarter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyClinicMigrations();
}

app.UseHttpsRedirection();

app.MapCarter();
app.Run();

