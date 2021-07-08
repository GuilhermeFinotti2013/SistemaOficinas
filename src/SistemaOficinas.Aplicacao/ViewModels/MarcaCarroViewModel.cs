using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaOficinas.Aplicacao.ViewModels
{
    public class MarcaCarroViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [DisplayName(displayName: "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres!", MinimumLength = 3)]
        public string Nome { get; set; }
    }
}
