﻿using Architecture.Repository;
using Infrastructure.Configuration;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebAPI.Middleware;

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

            services.AddScoped<IDatabaseFactory, DefaultDatabaseFactory>();

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

            app.UseWhen(x => !(x.Request.Path.StartsWithSegments("/api/user/login", StringComparison.OrdinalIgnoreCase)),
                builder =>
                {
                    builder.UseMiddleware<AuthenticationMiddleware>();
                });

            app.UseResponseCompression();

            app.UseMvc();
        }
    }
}
