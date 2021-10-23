using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitchSaga.Application.Services;

namespace WitchSaga.Application
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddWitchs(this IServiceCollection services)
        {
            services.AddTransient<IPeopleService, PeopleService>();
            services.AddTransient<IKillService, KillService>();
            return services;
        }
    }
}
