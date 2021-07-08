using SistemaOficinas.Data.ORM;
using SistemaOficinas.Data.Repositorio.Base;
using SistemaOficinas.Domain.Entities;
using SistemaOficinas.Domain.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaOficinas.Data.Repositorio
{
    public class FormaPagamentoRepositorio : RepositorioGenerico<FormaPagamento, Guid>, IFormaPagamentoRepositorio
    {
        private readonly OficinasDbContext _contexto;

        public FormaPagamentoRepositorio(OficinasDbContext context) : base(context)
        {
            _contexto = context;
        }

        public bool FormaPagamentoExiste(Guid id)
        {
            return _contexto.FormaPagamento.Any(x => x.Id == id);
        }
    }
}
