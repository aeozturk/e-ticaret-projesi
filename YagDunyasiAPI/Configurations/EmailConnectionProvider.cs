using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.EmailSender.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YagDunyasiAPI.Configurations
{
    public static class EmailConnectionProvider
    {
        public static IServiceCollection AddEmailConnectionProvider(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IEmailConfiguration>(configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            return services;
        }
    }
}
