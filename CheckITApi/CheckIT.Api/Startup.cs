﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace Exercise1Console
{
    /// <summary>
    /// Startup configuration file for Check IT api
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvcCore()
                .AddJsonFormatters()
                .AddApiExplorer();
            services.AddLogging();//Save for another feature
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "CheckITApiConsole", Version = "v1" });
            });
            
            services.AddTransient<IPathValidator, PathValidator>();
            services.AddTransient<IDirectoryWrapper, DirectoryWrapper>();
            services.AddTransient<IFileFinder, FileFinder>();
            services.AddTransient<IFileReader, FileReader>();
            services.AddTransient<IVolumeLoader, VolumeLoader>();
            services.AddTransient<IFactory, Factory>();
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Check IT API V1");
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
                    $"Time is: {DateTime.Now.ToString("t")}");
            });
        }
    }
}