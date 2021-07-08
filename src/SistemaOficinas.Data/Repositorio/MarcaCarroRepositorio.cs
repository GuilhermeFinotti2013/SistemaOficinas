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
    public class MarcaCarroRepositorio : RepositorioGenerico<MarcaCarro, Guid>, IMarcaCarroRepositorio
    {
        private readonly OficinasDbContext _contexto;

        public MarcaCarroRepositorio(OficinasDbContext context) : base(context)
        {
            _contexto = context;
        }

        public bool MarcaCarroExiste(Guid id)
        {
            return _contexto.MarcaCarro.Any(x => x.Id == id);
        }
    }
}
