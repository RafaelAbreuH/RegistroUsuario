﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsuario.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string NivelUsuario { get; set; }
        public String Usuario { get; set; }
        public string Clave { get; set; }
        public DateTime FechaIngreso { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Nombre = String.Empty;
            Email = String.Empty;
            Clave = String.Empty;
            NivelUsuario = String.Empty;
            Usuario = String.Empty;
            FechaIngreso = DateTime.Now;
        }
    }
}
