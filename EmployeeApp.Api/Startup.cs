using EmployeeApp.Api.Services;
using EmployeeApp.Dal.Contexts;
using EmployeeApp.Dal.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //for services
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<PlayGroundContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("PlayGroundContext")));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddControllers();
            //services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory

            services.AddSingleton<ISingleton, ScopeService>();
            services.AddTransient<ITransient, ScopeService>();
            services.AddScoped<IScoped, ScopeService>();



            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            //services.AddCors(options => options.AddDefaultPolicy( //can use app.UseCors();
            //        builder => builder.AllowAnyOrigin()));
            //services.AddCors(options => options.AddDefaultPolicy( //can use app.UseCors();
            //    builder => builder.WithOrigins("http://localhost:4200")));

            services.AddCors(options =>
            { 
                options.AddDefaultPolicy( //while this would be used everywhere else
                     builder => builder.WithOrigins("http://localhost:4200"));
                options.AddPolicy("myPolicy", builder => builder.WithOrigins("http://localhost:4200")); //can target something like just controllers
                });
        }

        //for middleware
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            //add cors middleware has to be after userouting and before useAuthorization
            // app.UseCors(); //since were using AddDefaultPolicy can leave it like this will see in response headers when call endpoint (access-control-allow-origin: *)--meaning any website will be able to access this endpoint, but can usually pass policy name
            // app.UseCors("myPolicy"); // with both a default policy and another policy, this will remove default policy though
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors("myPolicy");
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
