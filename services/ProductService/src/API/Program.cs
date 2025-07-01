using API;
using API.Extensions;
using Application;
using Infrastructure;
using Shared;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddShared()
    .AddAPI()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.UseHttpsRedirection();

app.MapEndpoints();

//if (app.Environment.IsDevelopment())
//{
//    app.MapScalarApiReference();
//    app.MapOpenApi();
//    app.ApplyMigrations();
//}

app.MapGet("/ping", () => "pong");

await app.RunAsync();