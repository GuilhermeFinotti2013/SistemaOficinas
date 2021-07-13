using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaOficinas.Aplicacao.ViewModels;
using X.PagedList;

namespace SistemaOficinas.Aplicacao.Interfaces
{
    public interface IMarcaCarroApplicationService
    {
        Task<IPagedList<MarcaCarroViewModel>> Listar(int itensPorPagina, string ordenacao, int? pagina);
        Task<MarcaCarroViewModel> ObterMarcaCarro(Guid idMarca);
        bool MarcaCarroExiste(Guid idMarca);
    }
}
