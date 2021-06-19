﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaOficinas.Domain.Models;
using SistemaOficinas.Domain.Interfaces.Repositorio;

namespace SistemaOficinas.Mvc.Controllers
{
    public class MarcaCarroController : Controller
    {
        private readonly IMarcaCarroRepositorio _marcaCarroRepositorio;

        public MarcaCarroController( IMarcaCarroRepositorio marcaCarroRepositorio)
        {
            _marcaCarroRepositorio = marcaCarroRepositorio;
        }

        // GET: MarcaCarro
        public async Task<IActionResult> Index()
        {
            return View(await _marcaCarroRepositorio.Listar());
        }

        // GET: MarcaCarro/Details/5
        public async Task<IActionResult> Details(Guid id)
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
            return _marcaCarroRepositorio.MarcaCarroExiste(id);
        }
    }
}