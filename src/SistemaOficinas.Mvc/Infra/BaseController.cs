using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaOficinas.Mvc.Infra
{
    public abstract class BaseController : Controller
    {
        private readonly IConfiguration _configuration;

        public BaseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected Int32 GetQuantidadeItensPorPagina()
        {
            return Convert.ToInt32(_configuration.GetSection("ConfiguracoesAplicacao").GetSection("Lista_QtdItensPagina").Value);
        }
    }
}
