using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaOficinas.Domain.Models;
using SistemaOficinas.DomainCore.Base;

namespace SistemaOficinas.Domain.Interfaces.Repositorio
{
    public interface IClienteRepositorio : IRepositorio<Cliente, Guid>
    {
        bool ClienteExiste(Guid id);
    }
}
