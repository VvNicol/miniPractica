using miniPractica.Servicios;
using miniPractica.Dtos;


namespace miniPractica.Controlador
{
    /// <summary>
    /// CLASE PROGRAM
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Aplicicaion principal
        /// <autor> nrojlla 13062024</autor>
        /// </summary>
        /// 
        public static List<UsuarioDto> ListaUsuario = new List<UsuarioDto>();

        public static string ficheroLog = $"{DateTime.Now.ToString("dd-MM-yyyy")} ficherolog.txt";
        static void Main(string[] args)
        {
            MenuInterface mi = new MenuImplementacion();

            try
            {
               int opcionSeleccionada;
                bool esCerrado = false;
                do
                {
                    opcionSeleccionada = mi.MenuPrincipal();
                    string mensaje = $"{DateTime.Now.ToString("dd/MM/yyy HH:mm:ss")} - Menu Inicial, opcion : {opcionSeleccionada} ";
                    switch (opcionSeleccionada)
                    {
                        case 0:
                            mensaje += "Cerrado";
                            esCerrado = true;
                            Console.WriteLine("Aplicacion cerrada");
                            break;
                        case 1:
                            mensaje += "Menu usuario";
                            mi.MenuUsuario();
                            break;

                        case 2:
                            mensaje += "Menu admin";
                            mi.MenuAdmin();
                            break;

                        default:
                            mensaje += "No valida";
                            Console.WriteLine("La opcion seleccionada no es valida");
                            break;
                    }
                    ficheroLogger(mensaje);

                } while (!esCerrado);

            }
            catch (Exception e) { Console.WriteLine($"No se ha podido leer/escribit ".Concat(e.ToString())); }
            
        }
        /// <summary>
        /// Fichero log
        /// </summary>
        /// <param name="mensaje"></param>
        private static void ficheroLogger(string mensaje)
        {
            try
            {
                using (StreamWriter log = new StreamWriter(ficheroLog, true))
                {
                    log.WriteLine(mensaje);
                }

            }
            catch (Exception e) { Console.WriteLine("No se ha podido escribir en el fichero".Concat(e.ToString())); }
        }
    }
}
