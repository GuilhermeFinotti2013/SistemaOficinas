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
    public class MarcaCarroRepositorio : RepositorioGenerico<MarcaCarro, Guid>, IMarcaCarroRepositorio
    {
        private readonly OficinasDbContext _contexto;

        public MarcaCarroRepositorio(OficinasDbContext context) : base(context)
        {
            this._contexto = context;
        }

        public bool MarcaCarroExiste(Guid id)
        {
            return _contexto.MarcaCarro.Any(x => x.Id == id);
        }
    }
}
