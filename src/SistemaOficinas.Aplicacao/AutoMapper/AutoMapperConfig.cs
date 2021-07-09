using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SistemaOficinas.Aplicacao.ViewModels;
using SistemaOficinas.Domain.Entities;

namespace SistemaOficinas.Aplicacao.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<FormaPagamento, FormaPagamentoViewModel>().ReverseMap();
            CreateMap<MarcaCarro, MarcaCarroViewModel>().ReverseMap();
        }
    }
}
