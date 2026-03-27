using Clinic.Infrastructure.Extensions;
using Clinic.Application.Extensions;
using Clinic.Shared.Infrastructure.DIExtensions;
using Carter;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddClinicInfrastructure(builder.Configuration);
builder.Services.AddClinicApplicationServices();
builder.Services.AddSharedInfrastructure(builder.Configuration);

builder.Services.AddHostedService<IntegrationEventBackgroundService>();

builder.Services.AddCarter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyClinicMigrations();
    app.ApplySharedMigrations();
}

app.UseExceptionHandler("/error"); 
app.UseHttpsRedirection();

app.Map("/error", (HttpContext context) =>
{
    var feature = context.Features.Get<IExceptionHandlerFeature>();
    var exception = feature?.Error;

    var statusCode = exception switch
    {
        ArgumentException => 400,
        InvalidOperationException => 400,
        KeyNotFoundException => 404,
        _ => 500
    };

    return Results.Problem(
        title: "An error occurred",
        detail: app.Environment.IsDevelopment()
            ? exception?.Message
            : "Something went wrong",
        statusCode: statusCode
    );
});

app.MapCarter();
app.Run();
