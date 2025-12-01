using Teste.Application.Interfaces;
using Teste.Application.Services;
using Teste.Infrastructure;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Meucors", policy =>
    {
        policy.WithOrigins("https://localhost:7142")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();              
    app.MapScalarApiReference();   
}

app.UseCors("Meucors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
