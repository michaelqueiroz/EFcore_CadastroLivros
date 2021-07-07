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
    public class LivroController : Controller
    {
        private readonly LivroContext _Contexto;

        public LivroController(LivroContext Contexto)
        {
            _Contexto = Contexto;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _Contexto.Livro.ToListAsync());
            //return View();
        }

        [HttpGet]
        public IActionResult CriarLivro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarLivro(Livro livro)
        {
            if (ModelState.IsValid)
            {
                _Contexto.Add(livro);
                await _Contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(livro);
            }
        }

        [HttpGet]
        public IActionResult AtualizarLivro(int? Id)
        {
            if (Id != null)
            {
                Livro livro = _Contexto.Livro.Find(Id);
                return View(livro);

            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarLivro(int? Id, Livro livro)
        {
            if (Id != null)
            {
                if (ModelState.IsValid)
                {
                    _Contexto.Livro.Update(livro);
                    await _Contexto.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(livro);

            }
            else return NotFound();
        }

        [HttpGet]
        public IActionResult ExcluirLivro(int? Id)
        {
            if (Id != null)
            {
                Livro livro = _Contexto.Livro.Find(Id);
                return View(livro);

            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirLivro(int? Id, Livro livro)
        {
            if (Id != null)
            {
                _Contexto.Livro.Remove(livro);
                await _Contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            else return NotFound();
        }


    }
}
