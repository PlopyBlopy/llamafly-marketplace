using API;
using API.Endpoints;
using API.Extensions;
using API.gRPC;
using Application;
using Infrastructure;
using Infrastructure.Database.Extensions;
using Scalar.AspNetCore;
using Shared;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddShared()
    .AddAPI()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

builder.Services.AddOpenApi();

var app = builder.Build();

app.UseExceptionHandler();
app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference(options =>
    {
        options
        .WithTitle("Profile Service")
        .WithTheme(ScalarTheme.Purple)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });

    app.ApplyMigrations();
}

app.UseHttpsRedirection();
app.MapEndpoints();

app.MapGet(Routes.PING, () => "pong");

//grpc services
app.MapGrpcService<ProfileGrpcService>();

await app.RunAsync();

public partial class Program;