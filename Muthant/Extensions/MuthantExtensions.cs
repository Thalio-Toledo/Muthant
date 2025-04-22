using Microsoft.Extensions.DependencyInjection;
using Muthant;
using Muthant.Profile_configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mystiqueMapper.Extensions
{
    public static class MuthantExtensions
    {
        public static IServiceCollection AddMuthant<TProfile>(this IServiceCollection services) where TProfile : Profile
        {
            services.AddSingleton<Profile,TProfile>();
            services.AddTransient<MuthantMapper>();
            return services;
        }

        public static IServiceCollection AddMuthant(this IServiceCollection services) 
        {
            services.AddTransient<MuthantMapper>();
            return services;
        }
    }
}
