using SistemaOficinas.Domain.Models;
using SistemaOficinas.DomainCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaOficinas.Domain.Interfaces.Repositorio
{
    public interface IMarcaCarroRepositorio : IRepositorio<MarcaCarro, Guid>
    {
        bool MarcaCarroExiste(Guid id);
    }
}
