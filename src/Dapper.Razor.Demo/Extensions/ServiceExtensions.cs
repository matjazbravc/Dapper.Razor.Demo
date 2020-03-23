﻿using Dapper.Razor.Demo.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dapper.Razor.Demo.Extensions
{
    /// <summary>
    /// Configure options
    /// </summary>
    public static class ServiceExtensions
    {
        public static void AppSettingsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IISOptions>(options => options.ForwardClientCertificate = false);
            services.Configure<SqlServerOptions>(configuration.GetSection(nameof(SqlServerOptions)));
        }
    }
}
