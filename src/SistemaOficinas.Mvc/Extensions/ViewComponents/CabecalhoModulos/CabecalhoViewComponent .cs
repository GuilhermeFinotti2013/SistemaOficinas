using Microsoft.AspNetCore.Mvc;
using SistemaOficinas.Mvc.Extensions.ViewComponents.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaOficinas.Mvc.Extensions.ViewComponents.CabecalhoModulos
{
    [ViewComponent(Name = "cabecalho")]
    public class CabecalhoViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string titulo, string subtitulo)
        {
            Modulo modulo = new Modulo();
            modulo.Titulo = titulo;
            modulo.Subtitulo = subtitulo;
            return View(modulo);
        }
    }
}
