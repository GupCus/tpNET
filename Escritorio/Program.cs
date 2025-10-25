using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
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
           
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //await usuarioRepository.CreateAdmin();
            Application.Run(new FormLogin());
        }
    }
}