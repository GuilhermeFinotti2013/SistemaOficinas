using AutoMapper;
using SistemaOficinas.Aplicacao.Interfaces;
using SistemaOficinas.Aplicacao.ViewModels;
using SistemaOficinas.Domain.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<MarcaCarroViewModel>> Listar()
        {
            return _mapper.Map<IEnumerable<MarcaCarroViewModel>>(await _marcaCarroRepositorio.Listar());
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
