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
    public class AutorController : Controller
    {
        private readonly LivroContext _Contexto;

        public AutorController(LivroContext Contexto)
        {
            _Contexto = Contexto;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _Contexto.Autor.ToListAsync());
            //return View();
        }

        [HttpGet]
        public IActionResult CriarAutor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarAutor(Autor autor)
        {
            if (ModelState.IsValid)
            {
                _Contexto.Add(autor);
                await _Contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(autor);
            }
        }

        [HttpGet]
        public IActionResult AtualizarAutor(int? Id)
        {
            if (Id != null)
            {
                Autor autor = _Contexto.Autor.Find(Id);
                return View(autor);

            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarAutor(int? Id, Autor autor)
        {
            if (Id != null)
            {
                if (ModelState.IsValid)
                {
                    _Contexto.Autor.Update(autor);
                    await _Contexto.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(autor);

            }
            else return NotFound();
        }

        [HttpGet]
        public IActionResult ExcluirAutor(int? Id)
        {
            if (Id != null)
            {
                Autor autor = _Contexto.Autor.Find(Id);
                return View(autor);

            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirAutor(int? Id, Autor autor)
        {
            if (Id != null)
            {
                _Contexto.Autor.Remove(autor);
                await _Contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            else return NotFound();
        }


    }
}

