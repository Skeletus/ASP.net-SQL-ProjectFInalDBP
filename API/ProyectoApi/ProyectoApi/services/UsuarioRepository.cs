using ProyectoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable disable
namespace ProyectoApi.services
{
    
    public class UsuarioRepository
    {
        private readonly bddefinitivaContext _contexto;
        bddefinitivaContext _contexto2 = new bddefinitivaContext();
        public static List<Usuario> lstUsuarios = new List<Usuario>();

        public void cargarDatos(List<Models.Usuario> cargados)
        {
            List<Models.Usuario> bdDatos = new List<Models.Usuario>();
            foreach(var bd in cargados)
            {
                lstUsuarios.Add(bd);    
            }
        }

        public List<Usuario> GetAllUsuarios(List<Models.Usuario> cargados)
        {
            cargarDatos(cargados);
            return lstUsuarios; 
        }

        public Usuario GetUsuarioById(int id)
        {
            var user = lstUsuarios.Where(u => u.Iduser == id).FirstOrDefault();
            if(user == null)
            {
                return null;
            }
            return user;
        }

        public void add(Usuario obj)
        {
            lstUsuarios.Add(obj);
        }
    }
}
