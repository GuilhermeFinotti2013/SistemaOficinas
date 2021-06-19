using SistemaOficinas.Data.ORM;
using SistemaOficinas.Domain.Interfaces.Repositorio;
using SistemaOficinas.Domain.Models;
using SistemaOficinas.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaOficinas.Aplicacao.Repositorio
{
    public class FormaPagamentoRepositorio : RepositorioGenerico<FormaPagamento, Guid>, IFormaPagamentoRepositorio
    {
        private readonly OficinasDbContext _contexto;

        public FormaPagamentoRepositorio(OficinasDbContext context) : base(context)
        {
            this._contexto = context;
        }

        public bool FormaPagamentoExiste(Guid id)
        {
            return _contexto.FormaPagamento.Any(x => x.Id == id);
        }
    }
}
