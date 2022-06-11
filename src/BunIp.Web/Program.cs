using BunIp.Web.Configs;
using Microsoft.AspNetCore.HttpOverrides;
using System.Text.Json;
using System.Text.Json.Serialization;

const string CORS_POLICY_NAME = "BUN_IP_CORS";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
});

builder.Services.AddSingleton<BunIpConfig>(service =>
{
    return builder.Configuration.GetSection("BunIp").Get<BunIpConfig>();
});

builder.Services.AddCors(options =>
{
    var bunIpConfig = builder.Configuration.GetSection("BunIp").Get<BunIpConfig>();
    var deploySites = bunIpConfig.DeploySite;

    var originUris = new Uri[]
    {
        deploySites.Hybrid.Uri,
        deploySites.IPv4.Uri,
        deploySites.IPv6.Uri
    };

    options.AddPolicy(CORS_POLICY_NAME, builder =>
        builder
            .WithOrigins(originUris.Select(u => u.ToString().TrimEnd('/')).ToArray())
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();
if (!app.Environment.IsDevelopment())
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

app.MapRazorPages();

app.Run();