using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomeAspProject.Services.Database.AdoDotNet
{
    public static class MvcAdoDotNetHelper
    {
        public static void AddAdoDotNetDataService(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDatabaseService, AdoDotNetDataService>((serv)=> new AdoDotNetDataService(connectionString));
        }
    }
}
