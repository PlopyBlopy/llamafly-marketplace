using Application;
using Infrastructure;
using Infrastructure.Database.Extensions;
using Scalar.AspNetCore;
using Shared;
using System.Reflection;
using Web.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddShared()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.MapEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
    app.ApplyMigrations();
}
app.UseHttpsRedirection();

app.Run();