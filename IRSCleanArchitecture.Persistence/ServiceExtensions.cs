using IRSCleanArchitecture.Application.Interfaces;
using IRSCleanArchitecture.Persistence.DbContext;
using IRSCleanArchitecture.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace IRSCleanArchitecture.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenceApp(this IServiceCollection services, ConfigurationManager configuration)
        {
            services               
               .AddContext(configuration)
               .AddPersistence();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static IServiceCollection AddContext(
            this IServiceCollection services, ConfigurationManager configuration)
        {
            var dapperSettings = new DapperSettings();
            configuration.Bind(DapperSettings.SectionName, dapperSettings);
            services.AddSingleton(Options.Create(dapperSettings));
            services.AddSingleton<DapperContext>();

            return services;
        }

        public static IServiceCollection AddPersistence(
           this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
