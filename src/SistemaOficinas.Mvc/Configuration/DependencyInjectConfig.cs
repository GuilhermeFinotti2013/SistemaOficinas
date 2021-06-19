using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaOficinas.Domain.Interfaces.Repositorio;
using SistemaOficinas.Aplicacao.Repositorio;

namespace SistemaOficinas.Mvc.Configuration
{
    public static class DependencyInjectConfig
    {
        public static IServiceCollection AddDependencyInjectConfig(this IServiceCollection services, IConfiguration configuration)
        {
            #region Repositórios
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IMarcaCarroRepositorio, MarcaCarroRepositorio>();
            #endregion
            return services;
        }
    }
}
