using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaOficinas.Repository.Base;
using SistemaOficinas.Domain.Models;
using SistemaOficinas.Data.ORM;
using SistemaOficinas.Domain.Interfaces.Entidades;

namespace SistemaOficinas.Repository.Entidades
{
    public class ClienteRepositorio : RepositorioGenerico<Cliente, Guid>, IClienteRepositorio
    {
        private readonly OficinasDbContext _contexto;

        public ClienteRepositorio(OficinasDbContext context) : base(context)
        {
            this._contexto = context;
        }

        public bool ClienteExiste(Guid id)
        {
            return _contexto.Cliente.Any(x => x.Id == id);
        }
    }
}
