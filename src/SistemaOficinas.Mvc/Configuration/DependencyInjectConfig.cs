using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaOficinas.Domain.Interfaces.Repositorio;
using SistemaOficinas.Data.Repositorio;
using SistemaOficinas.Aplicacao.Interfaces;
using SistemaOficinas.Aplicacao.Servicos;

namespace SistemaOficinas.Mvc.Configuration
{
    public static class DependencyInjectConfig
    {
        public static IServiceCollection AddDependencyInjectConfig(this IServiceCollection services, IConfiguration configuration)
        {
            #region Aplicação
            services.AddScoped<IMarcaCarroApplicationService, MarcaCarroApplicationService>();
            services.AddScoped<IFormaPagamentoApplicationService, FormaPagamentoApplicationService>();
            #endregion

            #region Domain -> Service

            #endregion

            #region Domain -> Repository

            #endregion

            #region Configurações
            services.AddSingleton<IConfiguration>(configuration);
            #endregion

            #region Repositórios
            services.AddScoped<IMarcaCarroRepositorio, MarcaCarroRepositorio>();
            services.AddScoped<IFormaPagamentoRepositorio, FormaPagamentoRepositorio>();
            #endregion
            return services;
        }
    }
}
