using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaOficinas.Domain.Interfaces.Repositorio;
using SistemaOficinas.Domain.Entities;
using SistemaOficinas.Aplicacao.Interfaces;
using X.PagedList;

namespace SistemaOficinas.Mvc.Controllers
{
    public class MarcaCarroController : Controller
    {
        private readonly IMarcaCarroRepositorio _marcaCarroRepositorio;
        private readonly IMarcaCarroApplicationService _marcaCarroApplicationService;

        public MarcaCarroController(IMarcaCarroRepositorio marcaCarroRepositorio, IMarcaCarroApplicationService marcaCarroApplicationService)
        {
            _marcaCarroRepositorio = marcaCarroRepositorio;
            _marcaCarroApplicationService = marcaCarroApplicationService;
        }

        // GET: MarcaCarro
        public async Task<IActionResult> Index(int? pagina, string ordenacao)
        {
            ViewData["ordenacao"] = ordenacao;
            string orderByKey = string.IsNullOrEmpty(ordenacao) ? "Nome_desc" : "";
            ViewData["OrderByNome"] = orderByKey;

            return View(await _marcaCarroApplicationService.Listar(pagina, orderByKey));
        }

        // GET: MarcaCarro/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var marcaCarro = await _marcaCarroApplicationService.ObterMarcaCarro(id);
            if (marcaCarro == null)
            {
                return NotFound();
            }

            return View(marcaCarro);
        }

        // GET: MarcaCarro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MarcaCarro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MarcaCarro marcaCarro)
        {
            if (ModelState.IsValid)
            {
                marcaCarro.Id = Guid.NewGuid();
                await _marcaCarroRepositorio.Inserir(marcaCarro);
                return RedirectToAction(nameof(Index));
            }
            return View(marcaCarro);
        }

        // GET: MarcaCarro/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var marcaCarro = await _marcaCarroApplicationService.ObterMarcaCarro(id);
            if (marcaCarro == null)
            {
                return NotFound();
            }
            return View(marcaCarro);
        }

        // POST: MarcaCarro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MarcaCarro marcaCarro)
        {
            if (id != marcaCarro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _marcaCarroRepositorio.Atualizar(marcaCarro);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaCarroExists(marcaCarro.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(marcaCarro);
        }

        // GET: MarcaCarro/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcaCarro = await _marcaCarroRepositorio.Obter(id);
            if (marcaCarro == null)
            {
                return NotFound();
            }

            return View(marcaCarro);
        }

        // POST: MarcaCarro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _marcaCarroRepositorio.ExcluirPorId(id);
            return RedirectToAction(nameof(Index));
        }

        private bool MarcaCarroExists(Guid id)
        {
            return _marcaCarroApplicationService.MarcaCarroExiste(id);
        }
    }
}
