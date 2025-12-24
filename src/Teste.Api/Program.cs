using Scalar.AspNetCore;
using Teste.Application.Interfaces;
using Teste.Application.Interfaces.Identity;
using Teste.Application.Interfaces.Repositories;
using Teste.Application.Service;
using Teste.Application.Services;
using Teste.Infrastructure;
using Teste.Infrastructure.Identity.Security;
using Teste.Infrastructure.Identity.Service;
using Teste.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Meucors", policy =>
    {
        policy.WithOrigins("https://localhost:7215")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddInfrastructure(builder.Configuration);


builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IProfileService, ProfileService>()
    ;
builder.Services.AddScoped<IIdentityAuthService, IdentityAuthService>();

builder.Services.AddScoped<ITokenService, JwtTokenService>();

builder.Services.AddScoped<IProfileRepository, ProfileRepository>();


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
