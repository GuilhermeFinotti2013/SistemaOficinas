using AutoMapper;
using SistemaOficinas.Aplicacao.Interfaces;
using SistemaOficinas.Aplicacao.ViewModels;
using SistemaOficinas.Domain.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace SistemaOficinas.Aplicacao.Servicos
{
    public class FormaPagamentoApplicationService : IFormaPagamentoApplicationService
    {
        private readonly IFormaPagamentoRepositorio _formaPagamentoRepositorio;
        private readonly IMapper _mapper;

        public FormaPagamentoApplicationService(IFormaPagamentoRepositorio formaPagamentoRepositorio, IMapper mapper)
        {
            _formaPagamentoRepositorio = formaPagamentoRepositorio;
            _mapper = mapper;
        }

        public bool FormaPagamentoExiste(Guid idFormaPagamento)
        {
            return _formaPagamentoRepositorio.FormaPagamentoExiste(idFormaPagamento);
        }

        public async Task<IEnumerable<FormaPagamentoViewModel>> Listar(int? pagina, string ordenacao = null)
        {
            int itensPorPagina = 20;
            int numeroPagina = (pagina ?? 1);

            if (string.IsNullOrEmpty(ordenacao))
            {
                ordenacao = "Descricao";
            }

            IEnumerable<FormaPagamentoViewModel> lista = _mapper.Map<IList<FormaPagamentoViewModel>>(await _formaPagamentoRepositorio.Listar(ordenacao));

            return await lista.ToPagedListAsync(numeroPagina, itensPorPagina);
        }

        public async Task<FormaPagamentoViewModel> ObterFormaPagamento(Guid idFormaPagamento)
        {
            return _mapper.Map<FormaPagamentoViewModel>(await _formaPagamentoRepositorio.Obter(idFormaPagamento));
        }
    }
}
