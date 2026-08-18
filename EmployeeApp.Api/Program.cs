using EmployeeApp.Application.Dtos;
using EmployeeApp.Application.Extensions;
using EmployeeApp.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var connectionString = config.GetConnectionString("PlayGroundContext");
var jwtSecret = config["ApplicationSettings:JwtSecret"];
builder.Services.Configure<ApplicationSettings>(config.GetSection("ApplicationSettings"));
builder.Services.SetupIdentityContext(connectionString, jwtSecret);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "V1 Api", Version = "v1" });
});

builder.Services.AddInfrastructureLayer();
builder.Services.AddApplicationLayer();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins(config["ApplicationSettings:ClientUrl"])
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// -------------------- APP PIPELINE --------------------

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Api");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
