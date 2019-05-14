using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RegistroUsuario.DAL;
using RegistroUsuario.Entidades;

namespace RegistroUsuario.BLL
{
    public class UsuariosBLL
    {
        //Guardar Usuario
        public static bool Guardar(Usuarios usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Usuario.Add(usuario) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        //Modificar Usuario
        public static bool Modificar(Usuarios usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(usuario).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        //Eliminar usuario
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Usuarios usuario = contexto.Usuario.Find(id);

                contexto.Usuario.Remove(usuario);
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }

        //para Buscar los usuario
        public static Usuarios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usuarios usuario = new Usuarios();
            try
            {
                usuario = contexto.Usuario.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return usuario;
        }

        //Lista
        public static List<Usuarios> Getlist(Expression<Func<Usuarios, bool>> expression)
        {
            List<Usuarios> usuario = new List<Usuarios>();
            Contexto contexto = new Contexto();
            try
            {
                usuario = contexto.Usuario.Where(expression).ToList();
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }
            return usuario;
        }

    }
}
