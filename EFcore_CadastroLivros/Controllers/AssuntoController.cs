using EFcore_CadastroLivros.Data;
using EFcore_CadastroLivros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFcore_CadastroLivros.Controllers
{
    public class AssuntoController : Controller
    {
        private readonly LivroContext _Contexto;
        public AssuntoController(LivroContext Contexto)
        {
            _Contexto = Contexto;            
        }

        public async Task<IActionResult> Index()
        {
            return View(await _Contexto.Assunto.ToListAsync());
            //return View();
        }

        [HttpGet]
        public IActionResult CriarAssunto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarAssunto(Assunto assunto)
        {
            if (ModelState.IsValid)
            {
                _Contexto.Add(assunto);
                await _Contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(assunto);
            }
        }

        [HttpGet]
        public IActionResult AtualizarAssunto(int? Id)
        {
            if (Id != null)
            {
                Assunto assunto = _Contexto.Assunto.Find(Id);
                return View(assunto);

            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarAssunto(int? Id, Assunto assunto)
        {
            if (Id != null)
            {
                if (ModelState.IsValid)
                {
                    _Contexto.Assunto.Update(assunto);
                    await _Contexto.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(assunto);

            }
            else return NotFound();
        }

        [HttpGet]
        public IActionResult ExcluirAssunto(int? Id)
        {
            if (Id != null)
            {
                Assunto assunto = _Contexto.Assunto.Find(Id);
                return View(assunto);

            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirAssunto(int? Id, Assunto assunto)
        {
            if (Id != null)
            {
                _Contexto.Assunto.Remove(assunto);
                await _Contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            else return NotFound();
        }
    }
}
