using Architecture.Repository;
using Infrastructure.Configuration;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebAPI.IdentityServer;

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

            //services.AddMvc();

            //Identity Server
            services.AddIdentityServer().AddDeveloperSigningCredential()
                .AddInMemoryClients(Config.GetClients())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryIdentityResources(Config.GetIdentityResources());

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = "Cookies";
            //    options.DefaultChallengeScheme = "oidc";
            //})
            //.AddCookie("Cookies")
            //.AddOpenIdConnect("oidc", options =>
            //{
            //    options.SignInScheme = "Cookies";

            //    options.Authority = "http://localhost:61106/";//Identity Server URL
            //    options.RequireHttpsMetadata = false;// make it false since we are not using https

            //    options.ClientId = "mvc";
            //    options.SaveTokens = true;
            //});

            services.AddMvcCore().AddAuthorization().AddJsonFormatters();

            services.AddAuthentication("Bearer") // it is a Bearer token
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:61106/"; //Identity Server URL
                    options.RequireHttpsMetadata = false; // make it false since we are not using https
                    options.ApiName = "api1"; //api name which should be registered in IdentityServer
                });

            ////Session服务
            //services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ////Session
            //app.UseSession();

            app.UseAuthentication(); // add the Authentication middleware

            app.UseMvc();
        }
    }
}
