using SistemaOficinas.Domain.Entities;
using SistemaOficinas.DomainCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaOficinas.Domain.Interfaces.Repositorio
{
    public interface IFormaPagamentoRepositorio : IRepositorio<FormaPagamento, Guid>
    {
        bool FormaPagamentoExiste(Guid id);
    }
}
