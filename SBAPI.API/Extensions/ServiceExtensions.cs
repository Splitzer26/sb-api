﻿using Microsoft.AspNetCore.Mvc;
namespace SBAPI.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;

                config.ReportApiVersions = true;
            });
        }
    }
}
