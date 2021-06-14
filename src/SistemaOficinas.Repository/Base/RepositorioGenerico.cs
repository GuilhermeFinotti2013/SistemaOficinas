using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SistemaOficinas.DomainCore.Base;
using SistemaOficinas.Data.ORM;
using Microsoft.EntityFrameworkCore;

namespace SistemaOficinas.Repository.Base
{
    public abstract class RepositorioGenerico<TEntidade, TChave> : IRepositorioGenerico<TEntidade, TChave> where TEntidade : class, new()
    {
        protected OficinasDbContext _contexto;

        public RepositorioGenerico(OficinasDbContext context)
        {
            _contexto = context;
        }

        public virtual async Task Atualizar(TEntidade entidade)
        {
            _contexto.Entry(entidade).State = EntityState.Modified;
            await this.SaveAsync();
        }

        public void Dispose()
        {
            _contexto?.DisposeAsync();
        }

        public virtual async Task Excluir(TEntidade entidade)
        {
            this._contexto.Entry(entidade).State = EntityState.Deleted;
            await this.SaveAsync();
        }

        public virtual async Task ExcluirPorId(TChave id)
        {
            TEntidade entity = await this.Obter(id);
            await this.Excluir(entity);
        }

        public virtual async Task Inserir(TEntidade entidade)
        {
            this._contexto.Set<TEntidade>().Add(entidade);
            await this.SaveAsync();
        }

        public virtual async Task<IEnumerable<TEntidade>> Listar(Expression<Func<TEntidade, bool>> quando = null)
        {
            if (quando == null)
            {
                return await this._contexto.Set<TEntidade>().AsNoTracking().ToListAsync();
            }
            return await this._contexto.Set<TEntidade>().AsNoTracking().Where(quando).ToListAsync();
        }

        public virtual async Task<TEntidade> Obter(TChave id)
        {
            return await this._contexto.Set<TEntidade>().FindAsync(id);
        }

        public virtual async Task<int> SaveAsync()
        {
            return await _contexto.SaveChangesAsync();
        }
    }
}
