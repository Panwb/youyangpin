using Infrastructure.Repository;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Http;
using YYP.ComLib.Services;
using YYP.ComLib.Middleware;
using YYP.Repository;
using YYP.Services;

namespace WebAPI
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
            services.AddOptions();
            services.Configure<ConnectionStrings>(Configuration.GetSection("AppSettings:ConnectionStrings"));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IDatabaseFactory, DefaultDatabaseFactory>();
            services.AddScoped<IWorkContext, DefaultWorkContext>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGoodRepository, GoodRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGoodService, GoodService>();

            services.AddResponseCompression();

            services.AddMvc();

            //Session服务
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Session
            app.UseSession();

            var nonAuthPaths = new[] {"/api/user/login", "/api/user/register"};//这些入口不做权限控制
            app.UseWhen(x =>
                {
                    foreach (var path in nonAuthPaths)
                    {
                        if (x.Request.Path.StartsWithSegments(path, StringComparison.OrdinalIgnoreCase))
                        {
                            return false;
                        }
                    }

                    return true;
                },
                builder => { builder.UseMiddleware<AuthenticationMiddleware>(); });

            app.UseResponseCompression();

            app.UseMvc();
        }
    }
}
