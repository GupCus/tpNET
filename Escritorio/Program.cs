using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repository;

namespace Escritorio
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            TPIContext context = new TPIContext();
            //UsuarioRepository usuarioRepository = new UsuarioRepository(context);

            ApplicationConfiguration.Initialize();
            //await usuarioRepository.CreateAdmin();
            Application.Run(new FormLogin());
        }
    }
}