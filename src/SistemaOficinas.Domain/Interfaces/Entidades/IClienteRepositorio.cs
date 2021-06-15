using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaOficinas.Domain.Models;
using SistemaOficinas.DomainCore.Base;

namespace SistemaOficinas.Domain.Interfaces.Entidades
{
    public interface IClienteRepositorio : IRepositorioGenerico<Cliente, Guid>
    {
    }
}
