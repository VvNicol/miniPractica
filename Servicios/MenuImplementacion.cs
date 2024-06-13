using miniPractica.Controlador;

namespace miniPractica.Servicios
{
    /// <summary>
    /// Detalle de los metodos de menu inerface
    /// <autor>nrojlla13062024</autor>
    /// </summary>
    internal class MenuImplementacion : MenuInterface
    {
        OperativaInterface oi = new OperativaImplementacion();
        /// <summary>
        /// Fichero log
        /// </summary>
        /// <param name="mensaje"></param>
        private static void ficheroLogger(string mensaje)
        {
            try
            {
                using (StreamWriter log = new StreamWriter(Program.ficheroLog, true))
                {
                    log.WriteLine(mensaje);
                }

            }
            catch (Exception e) { Console.WriteLine("No se ha podido escribir en el fichero".Concat(e.ToString())); }
        }
        public void MenuAdmin()
        {
            try
            {
                int opcionSeleccionada;
                bool esCerrado = false;
                do
                {
                    opcionSeleccionada = MenuVistaAdmin();
                    string mensaje = $"{DateTime.Now.ToString("dd/MM/yyy HH:mm:ss")} - Menu Admin  , opcion : {opcionSeleccionada} ";
                    switch (opcionSeleccionada)
                    {
                        case 0:
                            mensaje += "Volver";
                            esCerrado = true;
                            Console.WriteLine("Volver");
                            break;
                        case 1:
                            mensaje += "Validar usuario";
                            oi.ValidarUsuario();
                            break;

                        case 2:
                            mensaje += "Generar informe";
                            oi.GenerarInforme();
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

        private int MenuVistaAdmin()
        {
            try
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("Menu admin");
                Console.WriteLine("0.Volver");
                Console.WriteLine("1.Validar usuario");
                Console.WriteLine("2.Generar informe");
                Console.WriteLine("---------------------");
                int opcionElegida = Convert.ToInt32(Console.ReadLine());
                return opcionElegida;

            }
            catch (Exception) { throw; }
        }


        private int MenuVistaUsuario()
        {
            try
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("Menu usuario");
                Console.WriteLine("0.Volver");
                Console.WriteLine("1.Crear usuario");
                Console.WriteLine("2.Logearse");
                Console.WriteLine("---------------------");
                int opcionElegida = Convert.ToInt32(Console.ReadLine());
                return opcionElegida;

            }
            catch (Exception) { throw; }
        }

        public int MenuPrincipal()
        {
            try
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("Menu principal");
                Console.WriteLine("0.Cerrar");
                Console.WriteLine("1.Menu usuario");
                Console.WriteLine("2.Menu admin");
                Console.WriteLine("---------------------");
                int opcionElegida = Convert.ToInt32(Console.ReadLine());
                return opcionElegida;

            }
            catch (Exception) { throw; }
        }

        public void MenuUsuario()
        {
            try
            {
                int opcionSeleccionada;
                bool esCerrado = false;
                do
                {
                    opcionSeleccionada = MenuVistaUsuario();
                    string mensaje = $"{DateTime.Now.ToString("dd/MM/yyy HH:mm:ss")} - Menu Usuario, opcion : {opcionSeleccionada} ";
                    switch (opcionSeleccionada)
                    {
                        case 0:
                            mensaje += "Volver";
                            esCerrado = true;
                            Console.WriteLine("Volver");
                            break;
                        case 1:
                            mensaje += "Crear usuario";
                            oi.CrearUsuario();
                            break;

                        case 2:
                            mensaje += "Iniciar sesion";
                            oi.IniciarSesion();
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
    }

}