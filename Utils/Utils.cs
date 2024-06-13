using miniPractica.Controlador;
using miniPractica.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniPractica.Utils
{
    internal class Utils
    {
        public static long generarId()
        {
            long idCalcular;
            int tamanio = Program.ListaUsuario.Count();
            if (tamanio > 0)
            {
                idCalcular = Program.ListaUsuario.Count() + 1;
            }
            else
            {
                idCalcular = 1;
            }
            return idCalcular;
        }

        public static void MostrarListaValidar()
        {
            try
            {
                var validacion = Program.ListaUsuario.Where(v=>v.EsValido == false).ToList();
                validacion = validacion.OrderBy(v=>v.Id).ToList();

                foreach (UsuarioDto v in validacion)
                {
                    Console.WriteLine($"usuario: {v.Usuario} id: {v.Id}");
                }
            }
            catch (Exception e) { Console.WriteLine("No se ha podido escribir en el fichero".Concat(e.ToString())); }
        }
    }
}
