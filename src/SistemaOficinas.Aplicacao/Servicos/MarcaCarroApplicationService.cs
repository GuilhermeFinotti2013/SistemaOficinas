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
    public class MarcaCarroApplicationService : IMarcaCarroApplicationService
    {
        private readonly IMarcaCarroRepositorio _marcaCarroRepositorio;
        private readonly IMapper _mapper;

        public MarcaCarroApplicationService(IMarcaCarroRepositorio marcaCarroRepositorio, IMapper mapper)
        {
            _marcaCarroRepositorio = marcaCarroRepositorio;
            _mapper = mapper;
        }

        public async Task<IPagedList<MarcaCarroViewModel>> Listar(int itensPorPagina, string ordenacao, int? pagina)
        {
            int numeroPagina = (pagina ?? 1);

            if (string.IsNullOrEmpty(ordenacao))
            {
                ordenacao = "Nome";
            }

            IEnumerable<MarcaCarroViewModel> lista = _mapper.Map<IList<MarcaCarroViewModel>>(await _marcaCarroRepositorio.Listar(ordenacao));

            return await lista.ToPagedListAsync(numeroPagina,itensPorPagina);
        }

        public bool MarcaCarroExiste(Guid idMarca)
        {
            return _marcaCarroRepositorio.MarcaCarroExiste(idMarca);
        }

        public async Task<MarcaCarroViewModel> ObterMarcaCarro(Guid idMarca)
        {
            return _mapper.Map<MarcaCarroViewModel>(await _marcaCarroRepositorio.Obter(idMarca));
        }

    }
}
