using miniPractica.Controlador;
using miniPractica.Dtos;

namespace miniPractica.Servicios
{
    internal class OperativaImplementacion : OperativaInterface
    {
        public void CrearUsuario()
        {
            try
            {
                UsuarioDto usuario = new UsuarioDto();

                Console.WriteLine("----------------");
                Console.WriteLine("Ingrese nombre de usuario");
                string usu = Console.ReadLine();

                Console.WriteLine("Ingrese correo electronico");
                string correo = Console.ReadLine();

                Console.WriteLine("Ingrese contrasenia");
                string pwd = Console.ReadLine();

                DateTime fecha = DateTime.Now;

                usuario.Id = Utils.Utils.generarId();
                usuario.Usuario = usu;
                usuario.Correo = correo;
                usuario.Contrasenia = pwd;
                usuario.FechaCreacion = fecha;

                Program.ListaUsuario.Add(usuario);

                Console.WriteLine("Se ha creado el usuario con exito0");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void GenerarInforme()
        {
            try
            {
                DateTime fecha = SolicitudFecha();
                var condicion = Program.ListaUsuario.Where(v => v.EsValido && v.FechaCreacion.Date == fecha.Date).OrderBy(v => v.Usuario).ToList();
                string informe = $"{DateTime.Now.ToString("dd-MM-yyyy")} usuarios validos.txt";

                if (condicion.Count > 0)
                {
                    using (StreamWriter sw = new StreamWriter(informe, true))
                    {
                        foreach (UsuarioDto usuario in condicion)
                        {
                            sw.WriteLine($"usuario: {usuario.Usuario}, correo: {usuario.Correo}, id: {usuario.Id}, valido: {usuario.EsValido}");
                        }
                    }
                    Console.WriteLine("Informe generado con éxito.");
                }
                else
                {
                    Console.WriteLine("No hay usuarios para generar informe");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Solitar fecha
        /// </summary>
        /// <returns></returns>
        private DateTime SolicitudFecha()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Elija una fecha (dd-mm-yyyy):");
                    DateTime fecha = DateTime.Parse(Console.ReadLine());
                    return fecha;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Fecha inválida. Por favor, intente de nuevo.");
                }
            }
        }

        public void IniciarSesion()
        {
            try
            {
                Console.WriteLine("Ingrese su nombre de usuario");
                string usu = Console.ReadLine();

                Console.WriteLine("Ingrese contrasenia");
                string pwd = Console.ReadLine();


                foreach (UsuarioDto usua in Program.ListaUsuario)
                {
                    if (usua.EsValido == true && usua.Usuario.Equals(usu) && usua.Contrasenia.Equals(pwd))
                    {
                        Console.WriteLine("Ha iniciado sesion");
                    }
                    else { Console.WriteLine("Usuario,constrasenia incorrecta o verifique si ha sido validado"); }
                }

            }
            catch (Exception ex) { throw; }
        }

        public void ValidarUsuario()
        {
            try
            {
                Utils.Utils.MostrarListaValidar();

                Console.WriteLine("Ingrese id del usuario a validar");
                long ids = Convert.ToInt64(Console.ReadLine());

                foreach (UsuarioDto validar in Program.ListaUsuario)
                {
                    if (validar.Id.Equals(ids) && validar.EsValido == false)
                    {
                        validar.EsValido = true;
                        Console.WriteLine("Usuario validado");
                    }
                }
            }
            catch (Exception ex) { throw; }
        }
    }
}