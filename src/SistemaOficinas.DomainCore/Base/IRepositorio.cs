using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SistemaOficinas.DomainCore.Base
{
    public interface IRepositorio<TEntidade, TChave> : IDisposable where TEntidade : class
    {
        Task Atualizar(TEntidade entidade);
        Task Excluir(TEntidade entidade);
        Task ExcluirPorId(TChave id);
        Task Inserir(TEntidade entidade);
        Task<IEnumerable<TEntidade>> Listar(Expression<Func<TEntidade, bool>> quando = null);
        Task<TEntidade> Obter(TChave id);
        Task<int> SaveAsync();
    }
}
