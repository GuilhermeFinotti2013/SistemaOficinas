using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SistemaOficinas.DomainCore.Base;
using SistemaOficinas.Data.ORM;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace SistemaOficinas.Data.Repositorio.Base
{
    public abstract class RepositorioGenerico<TEntidade, TChave> : IRepositorio<TEntidade, TChave> where TEntidade : class, new()
    {
        protected OficinasDbContext _contexto;

        public RepositorioGenerico(OficinasDbContext context)
        {
            _contexto = context;
        }

        public virtual async Task Atualizar(TEntidade entidade)
        {
            _contexto.Entry(entidade).State = EntityState.Modified;
            await SaveAsync();
        }

        public void Dispose()
        {
            _contexto?.DisposeAsync();
        }

        public virtual async Task Excluir(TEntidade entidade)
        {
            _contexto.Entry(entidade).State = EntityState.Deleted;
            await SaveAsync();
        }

        public virtual async Task ExcluirPorId(TChave id)
        {
            TEntidade entity = await Obter(id);
            await Excluir(entity);
        }

        public virtual async Task Inserir(TEntidade entidade)
        {
            _contexto.Set<TEntidade>().Add(entidade);
            await SaveAsync();
        }

        public virtual async Task<IList<TEntidade>> Listar(string ordenacao = null, Expression < Func<TEntidade, bool>> quando = null)
        {
            List<TEntidade> lista;

            if (string.IsNullOrEmpty(ordenacao))
            {
                ordenacao = "Id";
            }
            if (ordenacao.EndsWith("_desc"))
            {
                ordenacao = ordenacao.Substring(0, ordenacao.Length - 5);
                lista = await _contexto.Set<TEntidade>().OrderByDescending(x => EF.Property<object>(x, ordenacao))
                    .AsNoTracking().ToListAsync();
            }
            else
            {
                lista = await _contexto.Set<TEntidade>().OrderBy(x => EF.Property<object>(x, ordenacao))
                    .AsNoTracking().ToListAsync();
            }

            /*if (quando == null)
            {
                return await _contexto.Set<TEntidade>().AsNoTracking().ToListAsync();
            }*/
            return await lista.ToListAsync();
        }

        public virtual async Task<TEntidade> Obter(TChave id)
        {
            return await _contexto.Set<TEntidade>().FindAsync(id);
        }

        public virtual async Task<int> SaveAsync()
        {
            return await _contexto.SaveChangesAsync();
        }
    }
}
