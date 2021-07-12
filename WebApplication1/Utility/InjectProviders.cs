using Microsoft.Extensions.DependencyInjection;
using PharmacyService.DataAccess.Providers.Contract;
using PharmacyService.DataAccess.Providers.Services;
using PharmacyService.Infrastructure.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Utility
{
    public static class InjectProviders
    {
        public static IServiceCollection InjectServices(this IServiceCollection services) 
        {
            #region helpers
            services.AddScoped<IEncryption, Encryption>();
            #endregion
            #region Main Providers
            services.AddScoped<IInvoicesDataProvider, InvoicesDataProvider>();
            services.AddScoped<IProductManagementDataProvider, ProductManagementDataProvider>();
            services.AddScoped<IServicesDataProvider, ServicesDataProvider>();
            services.AddScoped<IUnitsDataProvider, UnitsDataProvider>();
            #endregion
            return services;
        }
    }
}
