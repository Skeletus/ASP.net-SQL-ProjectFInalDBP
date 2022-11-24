using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLastBreath.Helpers;
using MyLastBreath.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace MyLastBreath.Controllers
{
    public class CursosController : Controller
    {
        private readonly bddefinitivaContext _context;

        public CursosController(bddefinitivaContext context)
        {
            _context = context;
        }
        public IActionResult ListadoCursos()
        {
            var lst = _context.Cursos.Include(c => c.AreaNavigation).Include(c => c.DificultadNavigation)
                                        .Include(c=> c.DisponibilidadNavigation).Include(c=> c.ProfesorAsignadoNavigation);
            //var lst = _context.Cursos;
            return View(lst);
        }
        public IActionResult BuscarVista(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }


            if(id == 1)
            {
                return View("VistaCurso1");
            }
            if(id == 2)
            {
                return View("VistaCurso2");
            }
            if (id == 3)
            {
                return View("VistaCurso3");
            }
            if (id == 4)
            {
                return View("VistaCurso4");  
            }
            return View();
        }

        public IActionResult VistaCurso1()
        {
            return View();
        }

        public IActionResult VistaCurso2()
        {
            return View();
        }
        public IActionResult VistaCurso3()
        {
            return View();
        }
        public IActionResult VistaCurso4()
        {
            return View();
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos
                .Include(c => c.AreaNavigation)
                .Include(c => c.DificultadNavigation)
                .Include(c => c.DisponibilidadNavigation)
                .Include(c => c.ProfesorAsignadoNavigation)
                .FirstOrDefaultAsync(m => m.Idcurso == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        public IActionResult Inscribir()
        {
            var Obj = JsonConvert.DeserializeObject<Usuario>
                    (HttpContext.Session.GetString("susuario"));

            ViewData["Idcursox"] = new SelectList(_context.Cursos, "Idcurso", "NombreCurso");
            ViewData["Idusuariox"] = new SelectList(_context.Usuarios, "Iduser", "Nickname");
            return View();
        }

        // POST: Cursousuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inscribir([Bind("Idregistro,Idusuariox,Idcursox")] Cursousuario cursousuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursousuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListadoCursos));
            }
            ViewData["Idcursox"] = new SelectList(_context.Cursos, "Idcurso", "Idcurso", cursousuario.Idcursox);
            ViewData["Idusuariox"] = new SelectList(_context.Usuarios, "Iduser", "Password", cursousuario.Idusuariox);
            return View(cursousuario);
        }
    }
}
