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

namespace MyLastBreath.Controllers
{
    public class CursousuariosController : Controller
    {
        private readonly bddefinitivaContext _context;

        public CursousuariosController(bddefinitivaContext context)
        {
            _context = context;
        }

        // GET: Cursousuarios
        public async Task<IActionResult> Index()
        {
            var ObjSesion = HttpContext.Session.GetString("susuario");
            if (ObjSesion != null)
            {
                var Obj = JsonConvert.DeserializeObject<Usuario>
                    (HttpContext.Session.GetString("susuario"));
                var bdDefinitivaContext = _context.Cursousuarios.Include(c => c.IdcursoxNavigation).Include(c => c.IdusuarioxNavigation);
                ViewBag.usuarioxa = Obj.Nickname;
                //return View();
                return View(await bdDefinitivaContext.ToListAsync());
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
            //var bdDefinitivaContext = _context.Cursousuarios.Include(c => c.IdcursoxNavigation).Include(c => c.IdusuarioxNavigation);
            //return View(await bdDefinitivaContext.ToListAsync());
        }

        public IActionResult UserCursosPage()
        {
            var ObjSesion = HttpContext.Session.GetString("susuario");
            if (ObjSesion != null)
            {
                var Obj = JsonConvert.DeserializeObject<Usuario>
                    (HttpContext.Session.GetString("susuario"));
                var bdDefinitivaContextxd = _context.Cursousuarios
                    .Include(c=>c.IdcursoxNavigation).Include(c=>c.IdusuarioxNavigation).Where(c => c.Idusuariox == Obj.Iduser);
                
                return View(bdDefinitivaContextxd);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Cursousuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cursousuarios == null)
            {
                return NotFound();
            }

            var cursousuario = await _context.Cursousuarios
                .Include(c => c.IdcursoxNavigation)
                .Include(c => c.IdusuarioxNavigation)
                .FirstOrDefaultAsync(m => m.Idregistro == id);
            if (cursousuario == null)
            {
                return NotFound();
            }

            return View(cursousuario);
        }


        // GET: Cursousuarios/Create
        public IActionResult Create()
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
        public async Task<IActionResult> Create([Bind("Idregistro,Idusuariox,Idcursox")] Cursousuario cursousuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursousuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idcursox"] = new SelectList(_context.Cursos, "Idcurso", "Idcurso", cursousuario.Idcursox);
            ViewData["Idusuariox"] = new SelectList(_context.Usuarios, "Iduser", "Password", cursousuario.Idusuariox);
            return View(cursousuario);
        }

        // GET: Cursousuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cursousuarios == null)
            {
                return NotFound();
            }

            var cursousuario = await _context.Cursousuarios.FindAsync(id);
            if (cursousuario == null)
            {
                return NotFound();
            }
            ViewData["Idcursox"] = new SelectList(_context.Cursos, "Idcurso", "Idcurso", cursousuario.Idcursox);
            ViewData["Idusuariox"] = new SelectList(_context.Usuarios, "Iduser", "Password", cursousuario.Idusuariox);
            return View(cursousuario);
        }

        // POST: Cursousuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idregistro,Idusuariox,Idcursox")] Cursousuario cursousuario)
        {
            if (id != cursousuario.Idregistro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursousuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursousuarioExists(cursousuario.Idregistro))
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
            ViewData["Idcursox"] = new SelectList(_context.Cursos, "Idcurso", "Idcurso", cursousuario.Idcursox);
            ViewData["Idusuariox"] = new SelectList(_context.Usuarios, "Iduser", "Password", cursousuario.Idusuariox);
            return View(cursousuario);
        }

        // GET: Cursousuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cursousuarios == null)
            {
                return NotFound();
            }

            var cursousuario = await _context.Cursousuarios
                .Include(c => c.IdcursoxNavigation)
                .Include(c => c.IdusuarioxNavigation)
                .FirstOrDefaultAsync(m => m.Idregistro == id);
            if (cursousuario == null)
            {
                return NotFound();
            }

            return View(cursousuario);
        }

        // POST: Cursousuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cursousuarios == null)
            {
                return Problem("Entity set 'bdDefinitivaContext.Cursousuarios'  is null.");
            }
            var cursousuario = await _context.Cursousuarios.FindAsync(id);
            if (cursousuario != null)
            {
                _context.Cursousuarios.Remove(cursousuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursousuarioExists(int id)
        {
          return _context.Cursousuarios.Any(e => e.Idregistro == id);
        }
    }
}
