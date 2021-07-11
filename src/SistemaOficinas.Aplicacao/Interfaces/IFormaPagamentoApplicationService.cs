using SistemaOficinas.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaOficinas.Aplicacao.Interfaces
{
    public interface IFormaPagamentoApplicationService
    {
        Task<IEnumerable<FormaPagamentoViewModel>> Listar();
        Task<FormaPagamentoViewModel> ObterFormaPagamento(Guid idFormaPagamento);
        bool FormaPagamentoExiste(Guid idFormaPagamento);
    }
}
