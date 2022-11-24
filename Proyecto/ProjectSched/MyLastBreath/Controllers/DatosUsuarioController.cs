using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLastBreath.Models;
using Newtonsoft.Json;

namespace MyLastBreath.Controllers
{
    
    public class DatosUsuarioController : Controller
    {
        private readonly bddefinitivaContext _context;

        public DatosUsuarioController(bddefinitivaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var ObjSesion = HttpContext.Session.GetString("susuario");
            if (ObjSesion != null)
            {
                var Obj = JsonConvert.DeserializeObject<Usuario>
                    (HttpContext.Session.GetString("susuario"));
                //var bdDefinitivaContext = _context.Cursousuarios.Include(c => c.IdcursoxNavigation).Include(c => c.IdusuarioxNavigation);
                ViewBag.usuarioxa = Obj.Nickname;
                //return View();
                return View(Obj);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            //return View();
        }

    }

}
