using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniPractica.Dtos
{
    internal class UsuarioDto
    {
        long id;
        string usuario = "aaaaa";
        string correo = "aaaaa";
        string contrasenia = "aaaaa";
        bool esValido = false;
        DateTime fechaCreacion = new DateTime(9999, 12, 31);

        public UsuarioDto()
        {
        }

        public long Id { get => id; set => id = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        public bool EsValido { get => esValido; set => esValido = value; }
        public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
    }
}
