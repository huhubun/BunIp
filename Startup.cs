using IpTest.Configs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpTest
{
    public class Startup
    {
        private const string CORS_POLICY_NAME = "IP_TEST_CORS";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.Configure<DeploySite>(Configuration.GetSection("IpTest:DeploySite"));

            services.AddCors(options =>
            {
                var deploySites = Configuration.GetSection("IpTest:DeploySite").Get<DeploySite>();

                var origins = new Uri[]
                {
                    deploySites.Hybrid.Uri,
                    deploySites.IPv4.Uri,
                    deploySites.IPv6.Uri
                };

                options.AddPolicy(CORS_POLICY_NAME, builder =>
                    builder.WithOrigins(origins.Select(o => o.ToString().TrimEnd('/')).ToArray())
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                );
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

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(CORS_POLICY_NAME);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
