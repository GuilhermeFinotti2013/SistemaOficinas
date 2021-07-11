using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaOficinas.Aplicacao.ViewModels;

namespace SistemaOficinas.Aplicacao.Interfaces
{
    public interface IMarcaCarroApplicationService
    {
        Task<IEnumerable<MarcaCarroViewModel>> Listar();
        Task<MarcaCarroViewModel> ObterMarcaCarro(Guid idMarca);
        bool MarcaCarroExiste(Guid idMarca);
    }
}
