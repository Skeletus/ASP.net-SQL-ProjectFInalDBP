using Microsoft.EntityFrameworkCore;
using MyLastBreath.Helpers;
using MyLastBreath.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;


namespace MyLastBreath.Controllers
{
    public class MyCalendarController : Controller
    {
        private readonly bddefinitivaContext _context;

        public MyCalendarController(bddefinitivaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Models.Curso> xd = _context.Cursos.ToList();
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(xd);
            return View();
        }

        public async Task<IActionResult> CalendarioDelCurso(int? id)
        {
            List<Models.Curso> x2d = _context.Cursos.ToList();
            List<Models.Curso> xd = new List<Curso>();
            var cursousuario = await _context.Cursos
                .Include(c => c.AreaNavigation)
                .Include(c => c.DificultadNavigation)
                .Include(c => c.DisponibilidadNavigation)
                .Include(c => c.ProfesorAsignadoNavigation)
                .FirstOrDefaultAsync(m => m.Idcurso == id);
            
            //xd.Add(cursousuario);
            ViewData["EventsCurse"] = JSONListHelper.GetEventJSONString(x2d, id);
            return View();
        }
    }
}
