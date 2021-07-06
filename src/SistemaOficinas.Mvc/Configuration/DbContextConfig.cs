using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaOficinas.Data.ORM;

namespace SistemaOficinas.Mvc.Configuration
{
    public static class DbContextConfig
    {
        public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OficinasDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //services.addDa

            return services;
        }
    }
}
