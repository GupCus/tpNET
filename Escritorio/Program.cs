using System.Threading.Tasks;

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
            PlanificadorContext context = new PlanificadorContext();
            UsuarioRepository usuarioRepository = new UsuarioRepository(context);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            await usuarioRepository.CreateAdmin();
            Application.Run(new FormLogin());
        }
    }
}