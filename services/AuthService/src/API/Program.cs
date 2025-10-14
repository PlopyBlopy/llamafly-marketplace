using API;
using API.Endpoints;
using API.Extensions;
using Application;
using Infrastructure;
using Infrastructure.Database.Extensions;
using Scalar.AspNetCore;
using Shared;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddShared()
    .AddAPI(builder.Configuration)
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference(options =>
    {
        options
        .WithTitle("Auth Service")
        .WithTheme(ScalarTheme.Purple)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });

    app.ApplyMigrations();
}

app.UseExceptionHandler();

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapEndpoints();

app.MapGet(Routes.PING, () => "pong");

await app.RunAsync();

public partial class Program;