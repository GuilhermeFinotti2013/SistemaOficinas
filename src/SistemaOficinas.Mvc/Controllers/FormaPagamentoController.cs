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

namespace SistemaOficinas.Mvc.Controllers
{
    public class FormaPagamentoController : Controller
    {
        private readonly IFormaPagamentoRepositorio _formaPagamentoRepositorio;
        private readonly IFormaPagamentoApplicationService _formaPagamentoApplicationService;

        public FormaPagamentoController(IFormaPagamentoRepositorio formaPagamentoRepositorio, IFormaPagamentoApplicationService formaPagamentoApplicationService)
        {
            _formaPagamentoRepositorio = formaPagamentoRepositorio;
            _formaPagamentoApplicationService = formaPagamentoApplicationService;
        }

        // GET: FormaPagamento
        public async Task<IActionResult> Index(int? pagina)
        {
            return View(await _formaPagamentoApplicationService.Listar(pagina));
        }

        // GET: FormaPagamento/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var formaPagamento = await _formaPagamentoApplicationService.ObterFormaPagamento(id);
            if (formaPagamento == null)
            {
                return NotFound();
            }

            return View(formaPagamento);
        }

        // GET: FormaPagamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormaPagamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FormaPagamento formaPagamento)
        {
            if (ModelState.IsValid)
            {
                formaPagamento.Id = Guid.NewGuid();
                await _formaPagamentoRepositorio.Inserir(formaPagamento);
                return RedirectToAction(nameof(Index));
            }
            return View(formaPagamento);
        }

        // GET: FormaPagamento/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var formaPagamento = await _formaPagamentoApplicationService.ObterFormaPagamento(id);
            if (formaPagamento == null)
            {
                return NotFound();
            }
            return View(formaPagamento);
        }

        // POST: FormaPagamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, FormaPagamento formaPagamento)
        {
            if (id != formaPagamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _formaPagamentoRepositorio.Atualizar(formaPagamento);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormaPagamentoExists(formaPagamento.Id))
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
            return View(formaPagamento);
        }

        // GET: FormaPagamento/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaPagamento = await _formaPagamentoRepositorio.Obter(id);
            if (formaPagamento == null)
            {
                return NotFound();
            }

            return View(formaPagamento);
        }

        // POST: FormaPagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _formaPagamentoRepositorio.ExcluirPorId(id);
            return RedirectToAction(nameof(Index));
        }

        private bool FormaPagamentoExists(Guid id)
        {
            return _formaPagamentoApplicationService.FormaPagamentoExiste(id);
        }
    }
}
