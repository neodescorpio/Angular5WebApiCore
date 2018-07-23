using Angular5WebApiCore.Data;
using Angular5WebApiCore.Service.Locations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Angular5WebApiCore.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);
            //services.AddLogging();

            services.AddSingleton(new LoggerFactory()
                .AddConsole()
                .AddDebug());
            services.AddLogging();

            var connectionString = Configuration.GetConnectionString("DotNetCoreConnection");
            services.AddDbContext<AppDataContext>(d => d.UseSqlServer(connectionString), ServiceLifetime.Scoped);
            services.AddDbContext<AppDataContext>(options =>
               options.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(90))
            );
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(typeof(ICountryService), typeof(CountryService));
            //services.AddSingleton(typeof(IService<>), typeof(ServiceBase<>));

            services.AddScoped(typeof(IRepository<>), typeof(RepositoryEF<>));
            services.AddScoped<IUnitOfWork, UnitOfWork<AppDataContext>>();
            services.AddScoped<IUnitOfWork<AppDataContext>, UnitOfWork<AppDataContext>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseCors("CorsPolicy");

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "api/{controller=Values}/{action=Index}/{id?}");
            });
        }

    }
}
