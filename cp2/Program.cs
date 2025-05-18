using cp2.Application.UseCases;
using cp2.Application.Validators;
using cp2.Application.DTOs.Request;
using cp2.Application.DTOs.Response;
using cp2.Domain.Entity;
using cp2.Infrastructure.Context;
using cp2.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// http://localhost:5197/index.html

var connectionString = builder.Configuration.GetConnectionString("OracleMoto");


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(connectionString));

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UsuarioValidator>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CP2 API", Version = "v1" });
});

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IMotoRepository, MotoRepository>();

builder.Services.AddScoped<UsuarioUseCase>();
builder.Services.AddScoped<MotoUseCase>();

builder.Services.AddScoped<UsuarioValidator>();
builder.Services.AddScoped<MotoValidator>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CP2 API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
