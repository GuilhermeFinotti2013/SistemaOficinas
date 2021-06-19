using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaOficinas.Domain.Entities;

namespace SistemaOficinas.Domain.Models
{
    public class FormaPagamento : EntityBase
    {
        public string Descricao { get; set; }
    }
}
