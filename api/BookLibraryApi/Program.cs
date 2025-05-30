using BookLibraryApi.Config;
using BookLibraryApi.Endpoints;
using BookLibraryApi.Infra;

var builder = WebApplication.CreateBuilder(args);

var corsPolicyName = "frontend";

builder.Services
    .AddOpenApi()
    .AddCorsPolicy(corsPolicyName)
    .AddDbContext(builder.Configuration)
    .AddSwagger();

var app = builder.Build();

app.MapOpenApi();

app.UseSwaggerSetup()
   .UseApiEndpoints()
   .UseDbContext()
   .UseCors(corsPolicyName);


app.Run();