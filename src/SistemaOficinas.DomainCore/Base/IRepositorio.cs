using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace SistemaOficinas.DomainCore.Base
{
    public interface IRepositorio<TEntidade, TChave> : IDisposable where TEntidade : class
    {
        Task Atualizar(TEntidade entidade);
        Task Excluir(TEntidade entidade);
        Task ExcluirPorId(TChave id);
        Task Inserir(TEntidade entidade);
        Task<IList<TEntidade>> Listar(Expression<Func<TEntidade, bool>> quando = null);
        Task<TEntidade> Obter(TChave id);
        Task<int> SaveAsync();
    }
}
