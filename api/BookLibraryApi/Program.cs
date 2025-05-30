using BookLibraryApi.Config;
using BookLibraryApi.Controller;
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

app.UseSwagger()
   .UseSwaggerUI(c =>
   {
       c.SwaggerEndpoint("/swagger/v1/swagger.json", "Book Store Api v1");
   });

app.MapApiEndpoints()
   .UseCors(corsPolicyName);


app.Run();