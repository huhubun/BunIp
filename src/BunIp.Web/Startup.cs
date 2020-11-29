using BunIp.Web.Configs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BunIp.Web
{
    public class Startup
    {
        private const string CORS_POLICY_NAME = "BUN_IP_CORS";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            });

            services.AddSingleton<BunIpConfig>(service =>
            {
                return Configuration.GetSection("BunIp").Get<BunIpConfig>();
            });

            services.AddCors(options =>
            {
                var bunIpConfig = Configuration.GetSection("BunIp").Get<BunIpConfig>();
                var DeploySites = bunIpConfig.DeploySite;

                var originUris = new Uri[]
                {
                    DeploySites.Hybrid.Uri,
                    DeploySites.IPv4.Uri,
                    DeploySites.IPv6.Uri
                };

                options.AddPolicy(CORS_POLICY_NAME, builder =>
                    builder
                        .WithOrigins(originUris.Select(u => u.ToString().TrimEnd('/')).ToArray())
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

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
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(CORS_POLICY_NAME);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
