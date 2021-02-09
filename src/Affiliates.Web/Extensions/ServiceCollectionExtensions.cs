using System;

using Affiliates.Web.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Affiliates.Web
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration);
            services.Configure<LeadApiSettings>(configuration.GetSection(LeadApiSettings.SectionName));

            return services;
        }

        public static IServiceCollection AddCustomIntegrations(this IServiceCollection services, IConfiguration configuration)
        {
            var baseAddress = configuration.GetValue<string>("LeadApi:BaseUri");

            services.AddHttpClient<ILeadService, LeadService>(client => client.BaseAddress = new Uri(baseAddress)).AddHttpMessageHandler<ClientCredentialDelegatingHandler>();

            services.AddSingleton(provider => provider.GetService<IOptions<AppSettings>>()?.Value);
            services.AddSingleton(provider => provider.GetService<IOptions<LeadApiSettings>>()?.Value);

            services.AddTransient<ClientCredentialDelegatingHandler>();
            services.AddTransient<ITokenService, TokenService>();

            return services;
        }
    }
}