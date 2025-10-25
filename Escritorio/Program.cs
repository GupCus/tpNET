using System;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            //PlanificadorContext context = new PlanificadorContext();
            //UsuarioRepository usuarioRepository = new UsuarioRepository(context);

            ApplicationConfiguration.Initialize();
            //await usuarioRepository.CreateAdmin();
            Application.Run(new FormLogin());
        }
    }
}